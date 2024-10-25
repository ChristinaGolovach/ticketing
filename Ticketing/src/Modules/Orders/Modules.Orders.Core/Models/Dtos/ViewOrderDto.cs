using Modules.Orders.Data.Entities;

namespace Modules.Orders.Core.Models.Dtos
{
    public class ViewOrderDto
    {
        public Guid Id { get; set; }
        public Guid ActivityId { get; set; }
        public double Amount { get; set; }
        public OrderStatus Status { get; set; }
        public IList<ViewOrderItemDto> OrderItems { get; set; }
    }
}
