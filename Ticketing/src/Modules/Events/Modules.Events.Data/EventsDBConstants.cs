namespace Modules.Events.Data
{
    public static class EventsDBConstants
    {
        public static readonly string SchemaName = "events";
        public static readonly string DBConnectionKey = "Database";

        public static class ActivityTable
        {
            public static readonly string TableName = "Activities";
            public static readonly int StringMaxLength = 150;
        }

        public static class ActivityOfferTable
        {
            public static readonly string TableName = "ActivityOffers";
        }

        public static class RowTable
        {
            public static readonly string TableName = "Rows";
        }

        public static class SeatTable
        {
            public static readonly string TableName = "Seats";
        }

        public static class SeatOfferTable
        {
            public static readonly string TableName = "SeatOffers";
        }

        public static class SectionTable
        {
            public static readonly string TableName = "Sections";
        }

        public static class VenueTable
        {
            public static readonly string TableName = "Venues";
            public static readonly int StringMaxLength = 100;
        }
    }
}
