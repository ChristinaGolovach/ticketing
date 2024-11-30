using MediatR;

namespace Ticketing.Shared.Messaging.Requests
{
    public class SeatBookPessimisticLockRequest : IRequest<Unit>
    {
        public IList<Guid> SeatIds { get; set; }
    }
}
