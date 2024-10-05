using Ticketing.Shared.Data;

namespace Modules.Events.Data.Entities.VenueManifest
{
    public class Seat : BaseEntity
    {
        public int? Number { get; set; }
        // public bool GeneralAdmission { get => Number.HasValue; } // TODO: 
        public SeatState State { get; set; }
        public Guid RowId { get; set; }
        public Row Row { get; set; }
        public IList<SeatOffer> SeatOffers { get; set; }
    }
}
