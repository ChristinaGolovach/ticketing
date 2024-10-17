using Modules.Events.Data.Entities.VenueManifest;

namespace Modules.Events.Core.Models
{
    public class ViewActivityDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public Guid VenueId { get; set; }
        public ViewVenueDto Venue { get; set; }
    }
}
