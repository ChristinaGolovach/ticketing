using Microsoft.EntityFrameworkCore;
using Modules.Orders.Core.Models.Dtos;
using Modules.Orders.Data.Entities;
using Modules.Orders.Infrastructure.Data;
using Ticketing.Shared.Core.Exceptions;
using Ticketing.Shared.Infrastructure.Data;

namespace Modules.Orders.Core.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IRepository<OrderItem, OrdersDBContext> _repository;

        public OrderItemService(IRepository<OrderItem, OrdersDBContext> repository)
        {
            _repository = repository;
        }

        public async Task AddOrderItemAsync(Guid orderId, AddSeatDto seat, CancellationToken cancellationToken = default)
        {
            var orderItem = new OrderItem
            {
                OrderId = orderId,
                ActivitySeatId = seat.ActivitySeatId,
                Amount = seat.Amount
            };

            await _repository.AddAsync(orderItem, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteOrderItemAsync(Guid activitySeatId, CancellationToken cancellationToken = default)
        {
            var orderItem = await _repository.Query()
                .Where(item => item.ActivitySeatId == activitySeatId)
                .FirstOrDefaultAsync(cancellationToken);

            if (orderItem == null || orderItem.Deleted) 
            {
                throw new ResourceNotFoundException($"Seat {activitySeatId} is not found.");
            }

            _repository.Delete(orderItem);
            await _repository.SaveChangesAsync(cancellationToken);
        }
    }
}
