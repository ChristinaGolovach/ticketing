using MediatR;
using Modules.Events.Core.Services;
using Ticketing.Shared.Messaging.Requests;

namespace Modules.Events.ModuleApi
{
    public class SeatBookPessimisticLockHandler : IRequestHandler<SeatBookPessimisticLockRequest, Unit>
    {
        private readonly IActivitySeatService _activitySeatService;

        public SeatBookPessimisticLockHandler(IActivitySeatService activitySeatService)
        {
            _activitySeatService = activitySeatService;
        }

        public async Task<Unit> Handle(SeatBookPessimisticLockRequest request, CancellationToken cancellationToken)
        {
            await _activitySeatService.UpdateActivitySeatStatePessimisticLockAsync(request.SeatIds, Data.Entities.SeatState.Booked, cancellationToken);
            return Unit.Value;
        }
    }
}
