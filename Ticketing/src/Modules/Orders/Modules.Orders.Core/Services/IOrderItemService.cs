using Modules.Orders.Core.Models;

namespace Modules.Orders.Core.Services
{
    public interface IOrderItemService
    {
        Task AddOrderItemAsync(Guid orderId, AddSeatDto seat, CancellationToken cancellationToken = default);
    }
}
