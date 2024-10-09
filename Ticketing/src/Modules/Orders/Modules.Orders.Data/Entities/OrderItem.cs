using Ticketing.Shared.Data;

namespace Modules.Orders.Data.Entities
{
    public class OrderItem : BaseEntity
    {
        public double Amount { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public Guid ActivitySeatId { get; set; }
    }
}
