using Modules.Events.Data.Entities.VenueManifest;
using Ticketing.Shared.Data;

namespace Modules.Events.Data.Entities
{
    public class Activity : BaseEntity
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public Guid VenueId { get; set; }
        public Venue Venue { get; set; }
        public IList<ActivityOffer> ActivityOffers { get; set; }
        public IList<ActivitySeat> ActivitySeats { get; set; }

    }
}
