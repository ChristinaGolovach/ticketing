using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Modules.Events.Core.Models;
using Modules.Events.Data.Entities;
using Modules.Events.Infrastructure.Data;
using Ticketing.Shared.Core.Exceptions;
using Ticketing.Shared.Infrastructure.Data;

namespace Modules.Events.Core.Services
{
    public class ActivitySeatService : IActivitySeatService
    {
        private readonly IRepository<ActivitySeat, EventsDBContext> _repository;
        private readonly IMapper _mapper;

        public ActivitySeatService(IRepository<ActivitySeat, EventsDBContext> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ViewActivitySeatDto> GetActivitySeatAsync(Guid activitySeatId, CancellationToken cancellationToken = default)
        {
            var activitySeat = await _repository.GetByIdAsync(activitySeatId, cancellationToken);
            var activitySeatDto = _mapper.Map<ViewActivitySeatDto>(activitySeat);

            return activitySeatDto;
        }

        public async Task<SeatState> GetActivitySeatStateAsync(Guid activitySeatId, CancellationToken cancellationToken = default)
        {
            var activitySeat = await _repository.GetByIdAsync(activitySeatId, cancellationToken);

            return activitySeat.State;
        }

        public async Task UpdateActivitySeatStateAsync(IList<Guid> activitySeatIds, SeatState state, CancellationToken cancellationToken = default)
        {
            var activitySeats = await _repository.Query()
                 .Where(activitySeat => activitySeatIds.Contains(activitySeat.Id)).ToListAsync(cancellationToken);

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

        public async Task UpdateActivitySeatStateAsync(IDictionary<Guid, byte[]> activitySeatIds, SeatState state, CancellationToken cancellationToken = default)
        {
            var activitySeats = await _repository.Query()
                 .Where(activitySeat => activitySeatIds.Keys.Contains(activitySeat.Id)).ToListAsync(cancellationToken);

            foreach (var activitySeatId in activitySeatIds)
            {
                var activitySeat = activitySeats.FirstOrDefault(seat => seat.Id == activitySeatId.Key);
                if (activitySeat != null && !activitySeat.Version.SequenceEqual(activitySeatId.Value))
                {
                    throw new ResourceUnavailableException($"The seat {activitySeat.Id} is not available");
                }

                activitySeat.State = state;
            }

            await _repository.SaveChangesAsync(cancellationToken);
        }
    }
}
