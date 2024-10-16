
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Modules.Orders.Core.Models;
using Modules.Orders.Data;
using Modules.Orders.Data.Entities;
using Ticketing.Shared.Core.Exceptions;
using Ticketing.Shared.Data.Repository;
using Ticketing.Shared.Messaging.Requests;

namespace Modules.Orders.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order, OrdersDBContext> _repository;
        private readonly IOrderItemService _orderItemService;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;


        public OrderService(IRepository<Order, OrdersDBContext> repository,
            IOrderItemService orderItemService,
            IMediator mediator,
            IMapper mapper)
        {
            _repository = repository;
            _orderItemService = orderItemService;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<ViewOrderDto> GetOrderAsync(Guid userId, Guid orderId, CancellationToken cancellationToken = default)
        {
            var order = await _repository.Query()
                .AsNoTracking()
                .Include(order => order.OrderItems)
                .SingleOrDefaultAsync(order => order.Id == orderId);

            if (order == null) 
            {
                throw new ResourceNotFoundException($"Order {orderId} is not found.");
            }

            if (order.UserId != userId)
            {
                throw new ResourceNotFoundException($"User {userId} is not found.");
            }

            var viewOrder = _mapper.Map<ViewOrderDto>(order);

            return viewOrder;
        }

        public async Task<ViewOrderDto> AddSeatAsync(Guid userId, Guid orderId, AddSeatDto seat, CancellationToken cancellationToken = default)
        {
            var order = await GetOrderWithItemsAsync(orderId);

            if (order.UserId != userId)
            {
                throw new ResourceNotFoundException($"User {userId} is not found.");
            }

            if (order.OrderItems.Any(orderItem => orderItem.ActivitySeatId == seat.ActivitySeatId))
            {
                throw new ResourceDuplicateException($"Seat {seat.ActivitySeatId} is already added to order {orderId}.");
            }

            await _orderItemService.AddOrderItemAsync(orderId, seat, cancellationToken);

            order.Amount += seat.Amount;
            await _repository.SaveChangesAsync(cancellationToken);

            var viewOrder = _mapper.Map<ViewOrderDto>(order);

            return viewOrder;
        }

        public async Task<Guid> BookSeatsAsync(Guid userId, Guid orderId, CancellationToken cancellationToken = default)
        {
            var order = await GetOrderWithItemsAsync(orderId);
            await _mediator.Send(new SeatBookRequest
            {
                SeatIds = order.OrderItems.Select(orderItem => orderItem.ActivitySeatId).ToList()
            });

            var paymentId = await _mediator.Send(new PaymentNewRequest
            {
                OrderId = orderId,
                Amount = order.Amount
            });

            return paymentId;
        }

        public async Task DeleteSeatAsync(Guid userId, Guid orderId, Guid eventId, Guid activitySeatId, CancellationToken cancellationToken = default)
        {

        }

        public async Task UpdateOrderStatusAsync(Guid orderId, OrderStatus status, CancellationToken cancellationToken = default)
        {
            var order = await GetOrderWithItemsAsync(orderId);

            order.Status = status;
            _repository.Update(order);

            switch (status)
            {
                case OrderStatus.Failed:
                    await _mediator.Send(new SeatAvailableRequest
                    {
                        SeatIds = order.OrderItems.Select(orderItem => orderItem.ActivitySeatId).ToList()
                    },
                    cancellationToken);
                    break;
                case OrderStatus.Paid:
                    await _mediator.Send(new SeatSoldRequest
                    {
                        SeatIds = order.OrderItems.Select(orderItem => orderItem.ActivitySeatId).ToList()
                    },
                    cancellationToken);
                    break;
                default:
                    break;
            }

            await _repository.SaveChangesAsync(cancellationToken);
        }

        private async Task<Order> GetOrderWithItemsAsync(Guid orderId)
        {
            var order = await _repository.Query()
                .Include(order => order.OrderItems)
                .SingleOrDefaultAsync(order => order.Id == orderId);

            if (order == null)
            {
                throw new ResourceNotFoundException($"Order {orderId} is not found.");
            }

            return order;
        }
    }
}
