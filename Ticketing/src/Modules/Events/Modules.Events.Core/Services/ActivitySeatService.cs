using Microsoft.EntityFrameworkCore;
using Modules.Events.Data.Entities;
using Modules.Events.Infrastructure.Data;
using Ticketing.Shared.Infrastructure.Data;

namespace Modules.Events.Core.Services
{
    public class ActivitySeatService : IActivitySeatService
    {
        private readonly IRepository<ActivitySeat, EventsDBContext> _repository;
 
        public ActivitySeatService(IRepository<ActivitySeat, EventsDBContext> repository)
        {
            _repository = repository;
        }

        public async Task UpdateActivitySeatStateAsync(IList<Guid> activitySeatIds, SeatState state, CancellationToken cancellationToken= default)
        {
            var activitySeats = await _repository.Query()
                 .Where(activitySeat => activitySeatIds.Contains(activitySeat.Id)).ToListAsync();

            activitySeats.ForEach(a => a.State = state);

            await _repository.SaveChangesAsync(cancellationToken);

            //TODO: Investigate why it doesn't work now
            //await _repository.Query()
            //     .Where(activitySeat => activitySeatIds.Contains(activitySeat.Id))
            //     .ExecuteUpdateAsync(activitySeat =>
            //         activitySeat.SetProperty(a => a.State, a => state),
            //         cancellationToken
            //     );
        }
    }
}
