﻿using Ticketing.Shared.Data;

namespace Modules.Events.Data.Entities
{
    public class ActivityOffer : BaseEntity
    {
        public Guid ActivityId { get; set; }
        public Activity Activity { get; set; }
        public PriceType PriceType { get; set; }

        //[Range(0, double.MaxValue, ErrorMessage = "Value must be non-negative")] TODO Ask
        public double Amount { get; set; }
        public IList<ActivitySeatOffer> ActivitySeatOffers { get; set; }
    }
}
