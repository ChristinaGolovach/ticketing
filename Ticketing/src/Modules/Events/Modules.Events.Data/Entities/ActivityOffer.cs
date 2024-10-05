using Ticketing.Shared.Data;

namespace Modules.Events.Data.Entities
{
    public class ActivityOffer : BaseEntity
    {
        public Guid ActivityId { get; set; }
        public Activity Activity { get; set; }
        public PriceType PriceType { get; set; }
        public double Amount { get; set; }
        public IList<SeatOffer> SeatOffers { get; set; }
    }
}
