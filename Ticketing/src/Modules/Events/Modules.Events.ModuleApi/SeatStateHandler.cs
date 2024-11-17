using MediatR;
using Modules.Events.Core.Services;
using Ticketing.Shared.Messaging.Requests;
using Ticketing.Shared.Messaging.ResponseModels;


namespace Modules.Events.ModuleApi
{
    public class SeatStateHandler : IRequestHandler<SeatStateRequest, IList<SeatStatesResponse>>
    {
        private readonly IActivitySeatService _activitySeatService;

        public SeatStateHandler(IActivitySeatService activitySeatService)
        {
            _activitySeatService = activitySeatService;
        }

        public async Task<IList<SeatStatesResponse>> Handle(SeatStateRequest request, CancellationToken cancellationToken)
        {
            IList<SeatStatesResponse> response = new List<SeatStatesResponse>();
            foreach (var activitySeatId in request.ActivitySeatId)
            {
                var activitySeat = await _activitySeatService.GetActivitySeatAsync(activitySeatId, cancellationToken);
                response.Add(new SeatStatesResponse
                {
                    SeatId = activitySeatId,
                    State = (SeatState)(int)activitySeat.State,
                    Version = activitySeat.Version
                });
            }
            return response;
        }
    }
}
