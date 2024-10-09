using Modules.Events.Data.Entities.VenueManifest;
using Ticketing.Shared.Data;

namespace Modules.Events.Data.Entities
{
    public class ActivitySeat : BaseEntity
    {
        public SeatState State { get; set; }
        public Guid SeatId { get; set; }
        public Seat Seat { get; set; }
        public Guid ActivityId { get; set; }
        public Activity Activity { get; set; }
        public Guid ActivitySeatOfferId { get; set; }
        public ActivitySeatOffer ActivitySeatOffer { get; set; }

    }
}
