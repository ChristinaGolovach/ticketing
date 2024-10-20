
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Modules.Orders.Core.Models;
using Modules.Orders.Core.Models.Dtos;
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

        public async Task<ViewOrderDto> AddSeatAsync(Guid orderId, AddSeatDto seat, CancellationToken cancellationToken = default)
        {
            var order = await GetOrderWithItemsAsync(orderId);

            if (order.OrderItems.Any(orderItem => orderItem.ActivitySeatId == seat.ActivitySeatId))
            {
                throw new ResourceDuplicateException($"Seat {seat.ActivitySeatId} is already added to the order {orderId}.");
            }

            await _orderItemService.AddOrderItemAsync(orderId, seat, cancellationToken);

            order.Amount += seat.Amount;
            await _repository.SaveChangesAsync(cancellationToken);

            var viewOrder = _mapper.Map<ViewOrderDto>(order);

            return viewOrder;
        }

        public async Task<OrderActionResult> ApplyActionAsync(Guid orderId, OrderAction orderAction, CancellationToken cancellationToken = default)
        {
            var orderActionResponse = new OrderActionResult();

            switch (orderAction)
            {
                case OrderAction.Submit:
                    orderActionResponse = await SubmitOrderAsync(orderId, cancellationToken);
                    break;
                case OrderAction.Cancel:
                    throw new NotImplementedException();
                default:
                    throw new MethodNotAllowedException($"Order action {orderAction} is not allowed.");
            }

            return orderActionResponse;
        }

        public async Task DeleteSeatAsync(Guid orderId, Guid activitySeatId, CancellationToken cancellationToken = default)
        {
            var order = await _repository.GetByIdAsync(orderId);

            if (order == null || order.Deleted)
            {
                throw new ResourceNotFoundException($"Order {orderId} is not found.");
            }

            await _orderItemService.DeleteOrderItemAsync(activitySeatId, cancellationToken);
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

        private async Task<OrderActionResult> SubmitOrderAsync(Guid orderId, CancellationToken cancellationToken = default)
        {
            var order = await GetOrderWithItemsAsync(orderId);

            var seatIds = order.OrderItems.Select(orderItem => orderItem.ActivitySeatId).ToList();
            await BookSeatsAsync(seatIds, cancellationToken);

            var paymentId = await CreatePaymentAsync(order.Id, order.Amount, cancellationToken);

            order.Status = OrderStatus.InProgress;
            await _repository.SaveChangesAsync(cancellationToken);

            var orderActionResponse = new OrderActionResult
            {
                PaymentId = paymentId,
                OrderStatus = OrderStatus.InProgress
            };

            return orderActionResponse;
        }

        private async Task BookSeatsAsync(IList<Guid> seatId, CancellationToken cancellationToken = default)
        {
            await _mediator.Send(new SeatBookRequest
            {
                SeatIds = seatId
            }, cancellationToken);
        }

        private async Task<Guid> CreatePaymentAsync(Guid orderId, double amount, CancellationToken cancellationToken = default)
        {
            var paymentId = await _mediator.Send(new PaymentNewRequest
            {
                OrderId = orderId,
                Amount = amount
            }, cancellationToken);

            return paymentId;
        }

        private async Task<Order> GetOrderWithItemsAsync(Guid orderId)
        {
            var order = await _repository.Query()
                .Include(order => order.OrderItems.Where(orderItem => !orderItem.Deleted))
                .SingleOrDefaultAsync(order => order.Id == orderId && !order.Deleted);

            if (order == null)
            {
                throw new ResourceNotFoundException($"Order {orderId} is not found.");
            }

            return order;
        }
    }
}
