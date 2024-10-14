using MediatR;
using Modules.Events.Core.Services;
using Ticketing.Shared.Messaging.Requests;

namespace Modules.Events.ModuleApi
{
    public class AvailableSeatHandler : IRequestHandler<AvailableSeatRequest, Unit>
    {
        private readonly IActivitySeatService _activitySeatService;

        public AvailableSeatHandler(IActivitySeatService activitySeatService)
        {
            _activitySeatService = activitySeatService;
        }

        public async Task<Unit> Handle(AvailableSeatRequest request, CancellationToken cancellationToken)
        {
            await _activitySeatService.UpdateActivitySeatStateAsync(request.SeatIds, Data.Entities.SeatState.Available, cancellationToken);
            return Unit.Value;
        }
    }
}
