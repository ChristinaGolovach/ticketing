using MediatR;

namespace Ticketing.Shared.Messaging.Requests
{
    public class SeatBookRequest : IRequest<Unit>
    {
        public IDictionary<Guid, byte[]> SeatIds { get; set; }
    }
}
