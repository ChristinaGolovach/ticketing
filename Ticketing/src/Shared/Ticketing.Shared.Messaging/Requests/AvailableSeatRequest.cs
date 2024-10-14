using MediatR;

namespace Ticketing.Shared.Messaging.Requests
{
    public class AvailableSeatRequest : IRequest<Unit>
    {
        public IList<Guid> SeatIds { get; set; }
    }
}
