﻿using MediatR;
using Modules.Events.Core.Services;
using Ticketing.Shared.Messaging.Requests;

namespace Modules.Events.ModuleApi
{
    public class SoldSeatHandler : IRequestHandler<SoldSeatRequest, Unit>
    {
        private readonly IActivitySeatService _activitySeatService;

        public SoldSeatHandler(IActivitySeatService activitySeatService)
        {
            _activitySeatService = activitySeatService;
        }

        public async Task<Unit> Handle(SoldSeatRequest request, CancellationToken cancellationToken)
        {
            await _activitySeatService.UpdateActivitySeatStateAsync(request.SeatIds, Data.Entities.SeatState.Sold, cancellationToken);
            return Unit.Value;
        }
    }
}
