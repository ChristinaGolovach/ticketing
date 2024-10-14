using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Modules.Events.Core.Models;
using Modules.Events.Data;
using Modules.Events.Data.Entities;
using Ticketing.Shared.Core.Exceptions;
using Ticketing.Shared.Data.Repository;

namespace Modules.Events.Core.Services
{
    public class ActivityService : IActivityService
    {
        private IRepository<Activity, EventsDBContext> _repository;
        private IRepository<ActivitySeat, EventsDBContext> _repositoryActivitySeats;

        private IMapper _mapper;

        public ActivityService(
            IRepository<Activity, EventsDBContext> repository,
            IRepository<ActivitySeat, EventsDBContext> repositoryActivitySeats,
            IMapper mapper)
        {
            _repository = repository;
            _repositoryActivitySeats = repositoryActivitySeats;
            _mapper = mapper;
        }

        public async Task<IList<ViewActivityDto>> GetActivitiesAsync(CancellationToken cancellationToken = default)
        {
            var activities = await _repository.GetAllAsync(cancellationToken);
            var activitiesDto = _mapper.Map<IList<ViewActivityDto>>(activities);

            return activitiesDto;
        }

        public async Task<IList<ViewActivitySeatDto>> GetSeatsAsync(Guid activityId, Guid sectionId, CancellationToken cancellationToken = default)
        {
            var activity = await _repository.GetByIdAsync(activityId, cancellationToken);

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
    }
}
