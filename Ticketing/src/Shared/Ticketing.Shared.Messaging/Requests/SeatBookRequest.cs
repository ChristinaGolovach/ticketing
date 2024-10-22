using MediatR;

namespace Ticketing.Shared.Messaging.Requests
{
    public class SeatBookRequest : IRequest<Unit>
    {
        public IList<Guid> SeatIds { get; set; }
    }
}
