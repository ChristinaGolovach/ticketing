using Modules.Payments.Data.Entities;

namespace Modules.Payments.Core.Models
{
    public class ViewPaymentDto
    {
        public Guid Id { get; set; }
        public PaymentStatus Status { get; set; }
        public double Amount { get; set; }
    }
}
