using MediatR;

namespace Ticketing.Shared.Messaging.Requests
{
    public class SeatSoldRequest : IRequest<Unit>
    {
        public IList<Guid> SeatIds { get; set; }
    }
}
