﻿namespace Modules.Orders.Core.Models.Dtos
{
    public class ViewOrderItemDto
    {
        public Guid Id { get; set; }
        public Guid ActivitySeatId { get; set; }
        public double Amount { get; set; }
    }
}