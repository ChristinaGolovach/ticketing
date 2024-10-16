using Modules.Events.Core.Models;
using Ticketing.Shared.Data.Repository;
using Modules.Events.Data.Entities.VenueManifest;
using AutoMapper;
using Ticketing.Shared.Core.Exceptions;
using Microsoft.EntityFrameworkCore;
using Modules.Events.Data;

namespace Modules.Events.Core.Services
{
    public class VenueService : IVenueService
    {
        private readonly IRepository<Venue, EventsDBContext> _repository;
        private readonly IMapper _mapper;

        public VenueService(IRepository<Venue, EventsDBContext> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IList<ViewVenueDto>> GetVenuesAsync(CancellationToken cancellationToken = default)
        {
            var venues = await _repository.GetAllAsync(cancellationToken);
            var venuesDto = _mapper.Map<IList<ViewVenueDto>>(venues);

            return venuesDto;
        }

        public async Task<IList<ViewSectionDto>> GetSectionsAsync(Guid venueId, CancellationToken cancellationToken = default)
        {
            var venue = await _repository.Query()
                .AsNoTracking()
                .Include(x => x.Sections)
                .SingleOrDefaultAsync(x => x.Id == venueId, cancellationToken);

            if (venue == null) 
            {
                throw new ResourceNotFoundException($"Venue {venueId} is not found.");
            }

            var sectionsDto = _mapper.Map<IList<ViewSectionDto>>(venue.Sections);

            return sectionsDto;
        }
    }
}
