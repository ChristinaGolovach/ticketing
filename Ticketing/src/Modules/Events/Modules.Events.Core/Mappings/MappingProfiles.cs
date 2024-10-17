using AutoMapper;
using Modules.Events.Core.Models;
using Modules.Events.Data.Entities.VenueManifest;
using Modules.Events.Data.Entities;

namespace Modules.Events.Core.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Venue, ViewVenueDto>();//.ReverseMap();
            CreateMap<Activity, ViewActivityDto>();
        }
    }
}
