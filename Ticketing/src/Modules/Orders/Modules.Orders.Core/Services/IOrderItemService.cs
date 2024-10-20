using Modules.Orders.Core.Models.Dtos;

namespace Modules.Orders.Core.Services
{
    public interface IOrderItemService
    {
        Task AddOrderItemAsync(Guid orderId, AddSeatDto seat, CancellationToken cancellationToken = default);
        Task DeleteOrderItemAsync(Guid activitySeatId, CancellationToken cancellationToken = default);
    }
}
