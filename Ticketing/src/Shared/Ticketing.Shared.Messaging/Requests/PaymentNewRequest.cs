using MediatR;

namespace Ticketing.Shared.Messaging.Requests
{
    public class PaymentNewRequest : IRequest<Guid>
    {
        public Guid OrderId { get; set; }
        public double Amount { get; set; }
    }
}
