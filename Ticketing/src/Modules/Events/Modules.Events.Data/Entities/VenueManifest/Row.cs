using Ticketing.Shared.Data;

namespace Modules.Events.Data.Entities.VenueManifest
{
    public class Row : BaseEntity
    {
        public int Number { get; set; }
        public Guid SectionId { get; set; }
        public Section Section { get; set; }
        public IList<Seat> Seats { get; set; }
    }
}
