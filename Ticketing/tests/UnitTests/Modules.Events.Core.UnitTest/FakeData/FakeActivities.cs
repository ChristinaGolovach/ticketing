using Modules.Events.Data.Entities;

namespace Modules.Events.Core.UnitTest.FakeData
{
    public class FakeActivities
    {
        public static IQueryable<Activity> CreateFakeActivities()
        {
            var activitySeats = new List<Activity>()
            {
                new Activity
                {
                    Id = new Guid("cc99afbd-c379-4ba0-910b-3c4849192a5c"),
                    ActivitySeats = new List<ActivitySeat>
                    {
                        new ActivitySeat 
                        {
                            Id = new Guid("b631f5a0-0f96-4abb-9570-116b237e87b7"),
                            Seat = new Data.Entities.VenueManifest.Seat
                            {
                                Row = new Data.Entities.VenueManifest.Row
                                {
                                    SectionId = new Guid("1fc2fc05-6fa0-4672-ab9f-cd0662282532")
                                }
                            },
                            ActivitySeatOffer = new ActivitySeatOffer
                            {
                                ActivityOffer = new ActivityOffer { }
                            }
                        },
                        new ActivitySeat
                        {
                            Id = new Guid("e8508252-f763-4fa9-9c8b-1ef366e23dd8"),
                            Seat = new Data.Entities.VenueManifest.Seat
                            {
                                Row = new Data.Entities.VenueManifest.Row
                                {
                                    SectionId = new Guid("1fc2fc05-6fa0-4672-ab9f-cd0662282532")
                                }
                            },
                            ActivitySeatOffer = new ActivitySeatOffer
                            {
                                ActivityOffer = new ActivityOffer { }
                            }
                        }
                    }
                },
                new Activity
                {
                    Id = new Guid("cf970046-3124-4e9b-83c6-002b24d8eea4"),
                    ActivitySeats = new List <ActivitySeat>()
                }
            }.AsQueryable();

            return activitySeats;
        }
    }
}
