﻿using MediatR;
using Modules.Orders.Core.Services;
using Modules.Orders.Data.Entities;
using Ticketing.Shared.Messaging.Requests;

namespace Modules.Orders.ModuleApi
{
    public class OrderCompleteHandler : IRequestHandler<OrderCompleteRequest, Unit>
    {
        private readonly IOrderService _orderService;

        public OrderCompleteHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<Unit> Handle(OrderCompleteRequest request, CancellationToken cancellationToken)
        {
            await _orderService.UpdateOrderStatusAsync(request.OrderId, OrderStatus.Paid, cancellationToken);
            return Unit.Value;
        }
    }
}
