using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Modules.Events.Core.Models;
using Modules.Events.Data;
using Modules.Events.Data.Entities;
using Ticketing.Shared.Core.Exceptions;
using Ticketing.Shared.Data.Repository;

namespace Modules.Events.Core.Services
{
    public class ActivitySeatService : IActivitySeatService
    {
        private IRepository<ActivitySeat, EventsDBContext> _repository;

 
        public ActivitySeatService(IRepository<ActivitySeat, EventsDBContext> repository)
        {
            _repository = repository;
        }

        public async Task UpdateActivitySeatStateAsync(IList<Guid> activitySeatIds, SeatState state, CancellationToken cancellationToken)
        {
            var activitiesSeats = await _repository.Query()
                .Where(a => activitySeatIds.Contains(a.Id))
                .ToListAsync(cancellationToken);

            foreach (var activitiesSeat in activitiesSeats) 
            {
                activitiesSeat.State = state;
                _repository.Update(activitiesSeat);
            }

            await _repository.SaveChangesAsync(cancellationToken);
        }
    }
}
