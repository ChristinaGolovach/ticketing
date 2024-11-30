using MediatR;
using Microsoft.EntityFrameworkCore;
using Modules.Orders.Core.Models.Dtos;
using Modules.Orders.Data.Entities;
using Modules.Orders.Infrastructure.Data;
using Ticketing.Shared.Core.Exceptions;
using Ticketing.Shared.Infrastructure.Data;
using Ticketing.Shared.Messaging.Requests;
using Ticketing.Shared.Messaging.ResponseModels;

namespace Modules.Orders.Core.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IRepository<OrderItem, OrdersDBContext> _repository;
        private readonly IMediator _mediator;

        public OrderItemService(IRepository<OrderItem, OrdersDBContext> repository,
            IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task AddOrderItemAsync(Guid orderId, AddSeatDto seat, CancellationToken cancellationToken = default)
        {
            var activitySeats = new List<Guid>() { seat.ActivitySeatId };
            var activityStateResponse = await _mediator.Send(new SeatStateRequest { ActivitySeatId = activitySeats });

            if (activityStateResponse.Any(seat => seat.State != SeatState.Available))
            {
                throw new ResourceUnavailableException($"The seat {seat.ActivitySeatId} is unavailable.");
            }

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
