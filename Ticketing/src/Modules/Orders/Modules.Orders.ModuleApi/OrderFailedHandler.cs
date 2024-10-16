using MediatR;
using Modules.Orders.Core.Services;
using Modules.Orders.Data.Entities;
using Ticketing.Shared.Messaging.Requests;

namespace Modules.Orders.ModuleApi
{
    public class OrderFailedHandler : IRequestHandler<OrderFailedRequest, Unit>
    {
        private readonly IOrderService _orderService;

        public OrderFailedHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<Unit> Handle(OrderFailedRequest request, CancellationToken cancellationToken)
        {
            await _orderService.UpdateOrderStatusAsync(request.OrderId, OrderStatus.Failed, cancellationToken);

            return Unit.Value;
        }
    }
}
