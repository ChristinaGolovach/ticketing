using Ticketing.Shared.Data;

namespace Modules.Payments.Data.Entities
{
    public class Payment : BaseEntity
    {
        public PaymentStatus Status { get; set; }
        public double Amount { get; set; }
        public Guid OrderId { get; set; }
    }
}
