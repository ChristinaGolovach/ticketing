using Modules.Orders.Data.Entities;

namespace Modules.Orders.Core.Models
{
    public class OrderActionResult
    {
        public Guid? OrderId { get; set; }
        public Guid? PaymentId { get; set; }
        public OrderStatus? OrderStatus { get; set; }
    }
}
