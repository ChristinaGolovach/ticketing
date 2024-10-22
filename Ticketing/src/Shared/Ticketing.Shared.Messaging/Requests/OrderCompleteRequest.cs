using MediatR;

namespace Ticketing.Shared.Messaging.Requests
{
    public class OrderCompleteRequest : IRequest<Unit>
    {
        public Guid OrderId { get; set; }
        public Guid PaymentId { get; set; }
    }
}
