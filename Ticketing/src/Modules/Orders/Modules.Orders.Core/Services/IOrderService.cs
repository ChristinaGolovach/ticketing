using Modules.Orders.Data.Entities;

namespace Modules.Orders.Core.Services
{
    public interface IOrderService
    {
        Task UpdateOrderStatusAsync(Guid orderId, OrderStatus status, CancellationToken cancellationToken = default);
    }
}
