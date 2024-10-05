using Modules.Events.Data.Entities.VenueManifest;
using Ticketing.Shared.Data;

namespace Modules.Events.Data.Entities
{
    public class SeatOffer : BaseEntity
    {
        public Seat Seat { get; set; }
        public Guid OfferId { get; set; }
        public ActivityOffer Offer { get; set; }
    }
}
