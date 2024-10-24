﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Modules.Events.Core.Models;
using Modules.Events.Data.Entities;
using Modules.Events.Infrastructure.Data;
using Ticketing.Shared.Core.Exceptions;
using Ticketing.Shared.Infrastructure.Data;

namespace Modules.Events.Core.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IRepository<Activity, EventsDBContext> _repository;
        private readonly IMapper _mapper;

        public ActivityService(
            IRepository<Activity, EventsDBContext> repository,
            IMapper mapper)
        {
            _repository = repository;
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
