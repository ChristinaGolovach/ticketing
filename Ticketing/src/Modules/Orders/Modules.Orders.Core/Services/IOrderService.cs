﻿using Modules.Orders.Core.Models;
using Modules.Orders.Core.Models.Dtos;
using Modules.Orders.Data.Entities;

namespace Modules.Orders.Core.Services
{
    public interface IOrderService
    {
        Task<ViewOrderDto> GetOrderAsync(Guid userId, Guid orderId, CancellationToken cancellationToken = default);
        Task<ViewOrderDto> AddSeatAsync(Guid orderId, AddSeatDto seat, CancellationToken cancellationToken = default);
        Task DeleteSeatAsync(Guid orderId, Guid activitySeatId, CancellationToken cancellationToken = default);
        Task<OrderActionResult> ApplyActionAsync(Guid orderId, OrderAction orderAction, CancellationToken cancellationToken = default);
        Task UpdateOrderStatusAsync(Guid orderId, OrderStatus status, CancellationToken cancellationToken = default);
    }
}
