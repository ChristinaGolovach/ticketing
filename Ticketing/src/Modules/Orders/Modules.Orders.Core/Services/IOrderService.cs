using Modules.Orders.Core.Models;
using Modules.Orders.Data.Entities;

namespace Modules.Orders.Core.Services
{
    public interface IOrderService
    {
        Task<ViewOrderDto> GetOrderAsync(Guid userId, Guid orderId, CancellationToken cancellationToken = default);
        Task<ViewOrderDto> AddSeatAsync(Guid userId, Guid orderId, AddSeatDto seat, CancellationToken cancellationToken = default);
        Task DeleteSeatAsync(Guid userId, Guid orderId, Guid eventId, Guid activitySeatId, CancellationToken cancellationToken = default);
        Task<Guid> BookSeatsAsync(Guid userId, Guid orderId, CancellationToken cancellationToken = default);
        Task UpdateOrderStatusAsync(Guid orderId, OrderStatus status, CancellationToken cancellationToken = default);
    }
}
