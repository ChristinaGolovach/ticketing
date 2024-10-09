using Ticketing.Shared.Data;

namespace Modules.Events.Data.Entities.VenueManifest
{
    public class Venue : BaseEntity
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string BuildNumber { get; set; }
        public IList<Section> Sections { get; set; }
        public IList<Activity> Activities { get; set; }
    }
}
