using Ticketing.Shared.Data;

namespace Modules.Orders.Data.Entities
{
    public class Order : BaseEntity
    {
        public OrderStatus Status { get; set; }
        public double Amount { get; set; }
        public Guid UserId { get; set; }
        public Guid ActivityId { get; set; }
        public IList<OrderItem> OrderItems { get; set; }
    }
}
