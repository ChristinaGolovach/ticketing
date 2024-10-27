using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Modules.Events.Core.Models;
using Modules.Events.Data.Entities;
using Modules.Events.Infrastructure.Data;
using Ticketing.Shared.Core.Exceptions;
using Ticketing.Shared.Infrastructure.Cache;
using Ticketing.Shared.Infrastructure.Data;

namespace Modules.Events.Core.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IRepository<Activity, EventsDBContext> _repository;
        private readonly IMapper _mapper;
        private readonly ICacheService _cache;

        public ActivityService(
            IRepository<Activity, EventsDBContext> repository,
            IMapper mapper,
            ICacheService cache)
        {
            _repository = repository;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<IList<ViewActivityDto>> GetActivitiesAsync(CancellationToken cancellationToken = default)
        {
            var activities = await _repository.GetAllAsync(cancellationToken);
            var activitiesDto = _mapper.Map<IList<ViewActivityDto>>(activities);

            return activitiesDto;
        }

        public async Task<IList<ViewActivitySeatDto>> GetSeatsAsync(Guid activityId, Guid sectionId, CancellationToken cancellationToken = default)
        {
            Activity activity = await GetActivityAsync(activityId, cancellationToken);
            if (activity == null)
            {
                throw new ResourceNotFoundException($"Activity {activityId} is not found.");
            }

            var seats = await _repository.Query()
                .AsNoTracking()
                .Where(activity => activity.Id == activityId)
                .SelectMany(activity => activity.ActivitySeats)
                .Where(activitySeat => activitySeat.Seat.Row.SectionId == sectionId)
                .Select(activitySeat => new ViewActivitySeatDto
                {
                    Id = activitySeat.Id,
                    Number = activitySeat.Seat.Number,
                    RowId = activitySeat.Seat.RowId,
                    SectionId = activitySeat.Seat.Row.SectionId,
                    StateId = (int)activitySeat.State,
                    State = activitySeat.State,
                    PriceTypeId = (int)activitySeat.ActivitySeatOffer.ActivityOffer.PriceType,
                    PriceType = activitySeat.ActivitySeatOffer.ActivityOffer.PriceType,
                    Amount = activitySeat.ActivitySeatOffer.ActivityOffer.Amount
                })
                .ToListAsync(cancellationToken);

            return seats;
        }

        private async Task<Activity> GetActivityAsync(Guid activityId,  CancellationToken cancellationToken = default)
        {
            Activity activity = null;
            var cachedActivity = await _cache.GetAsync<Activity>(activityId.ToString(), cancellationToken);

            if (cachedActivity != null)
            {
                activity = cachedActivity;
            }
            else
            {
                activity = await _repository.GetByIdAsync(activityId, cancellationToken);
                await _cache.SetAsync(activityId.ToString(), activity);
            }

            return activity;
        }
    }
}
