using MediatR;

namespace Ticketing.Shared.Messaging.Requests
{
    public class SoldSeatRequest : IRequest<Unit>
    {
        public IList<Guid> SeatIds { get; set; }
    }
}
