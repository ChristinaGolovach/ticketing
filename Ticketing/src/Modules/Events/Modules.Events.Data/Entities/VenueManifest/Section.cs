using Ticketing.Shared.Data;

namespace Modules.Events.Data.Entities.VenueManifest
{
    public class Section : BaseEntity
    {
        public int Number { get; set; }
        public Guid VenueId { get; set; }
        public Venue Venue { get; set; }
        public IList<Row> Rows { get; set; }
    }
}
