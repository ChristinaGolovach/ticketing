using Modules.Events.Data.Entities.VenueManifest;
using Ticketing.Shared.Data;

namespace Modules.Events.Data.Entities
{
    public class SeatOffer : BaseEntity
    {
        public Guid SeatId { get; set; }
        public Seat Seat { get; set; }
        public Guid ActivityOfferId { get; set; }
        public ActivityOffer ActivityOffer { get; set; }
    }
}
