using Ticketing.Shared.Data;

namespace Modules.Events.Data.Entities
{
    public class ActivitySeatOffer : BaseEntity
    {
        public Guid ActivitySeatId { get; set; }
        public ActivitySeat ActivitySeat { get; set; }
        public Guid ActivityOfferId { get; set; }
        public ActivityOffer ActivityOffer { get; set; }
    }
}
