using MediatR;
using Ticketing.Shared.Messaging.ResponseModels;

namespace Ticketing.Shared.Messaging.Requests
{
    public class SeatStateRequest : IRequest<IList<SeatStatesResponse>>
    {
        public IList<Guid> ActivitySeatId { get; set; }

    }
}

