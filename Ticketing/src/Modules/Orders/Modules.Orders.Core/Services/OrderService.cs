
using MediatR;
using Microsoft.EntityFrameworkCore;
using Modules.Orders.Data;
using Modules.Orders.Data.Entities;
using Ticketing.Shared.Core.Exceptions;
using Ticketing.Shared.Data.Repository;
using Ticketing.Shared.Messaging.Requests;

namespace Modules.Orders.Core.Services
{
    public class OrderService : IOrderService
    {
        private IRepository<Order, OrdersDBContext> _repository;
        private readonly IMediator _mediator;

        public OrderService(IRepository<Order, OrdersDBContext> repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task UpdateOrderStatusAsync(Guid orderId, OrderStatus status, CancellationToken cancellationToken = default)
        {
            var order = await GetOrderWithItemsAsync(orderId);

            order.Status = status;
            _repository.Update(order);

            switch (status)
            {
                case OrderStatus.Failed:
                    await _mediator.Send(new AvailableSeatRequest
                    {
                        SeatIds = order.OrderItems.Select(orderItem => orderItem.ActivitySeatId).ToArray()
                    },
                    cancellationToken);
                    break;
                case OrderStatus.Paid:
                    await _mediator.Send(new SoldSeatRequest
                    {
                        SeatIds = order.OrderItems.Select(orderItem => orderItem.ActivitySeatId).ToArray()
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
                .AsNoTracking()
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
