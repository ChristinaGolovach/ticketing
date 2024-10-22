using MediatR;
using Modules.Events.Core.Services;
using Ticketing.Shared.Messaging.Requests;

namespace Modules.Events.ModuleApi
{
    public class SeatBookHandler : IRequestHandler<SeatBookRequest, Unit>
    {
        private readonly IActivitySeatService _activitySeatService;

        public SeatBookHandler(IActivitySeatService activitySeatService)
        {
            _activitySeatService = activitySeatService;
        }

        public async Task<Unit> Handle(SeatBookRequest request, CancellationToken cancellationToken)
        {
            await _activitySeatService.UpdateActivitySeatStateAsync(request.SeatIds, Data.Entities.SeatState.Booked, cancellationToken);
            return Unit.Value;
        }
    }
}
