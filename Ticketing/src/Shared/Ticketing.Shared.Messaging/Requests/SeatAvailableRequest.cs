using MediatR;

namespace Ticketing.Shared.Messaging.Requests
{
    public class SeatAvailableRequest : IRequest<Unit>
    {
        public IList<Guid> SeatIds { get; set; }
    }
}
