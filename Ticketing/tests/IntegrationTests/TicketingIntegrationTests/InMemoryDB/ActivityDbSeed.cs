using Modules.Events.Data.Entities;
using Modules.Events.Data.Entities.VenueManifest;
using Modules.Events.Infrastructure.Data;

namespace TicketingIntegrationTests.InMemoryDB
{
    public class ActivityDdSeed
    {
        public void DataSeed(EventsDBContext context)
        {
            SeedVenue(context);
            SeedSection(context);
            SeedRow(context);
            SeedSeat(context);
            SeedActivity(context);
            SeedActivityOffer(context);
            SeedActivitySeat(context);
            SeedActivitySeatOffer(context);
        }

        private void SeedVenue(EventsDBContext context)
        {
            context.Venues.AddRange(
                new Venue
                {
                    Id = new Guid("c82171f1-aa5f-4434-b0cd-90a8bedeb4af"),
                    Name = "Arena",
                    Country = "Poland",
                    City = "Lodz",
                    Street = "Kolobzesk",
                    BuildNumber = "15A"
                });
        }

        private void SeedSection(EventsDBContext context)
        {
            context.Sections.AddRange(
                new Section { Id = new Guid("B6A3C9E9-B7F5-425D-A716-D2D7F788F423"), Number = 1, VenueId = new Guid("c82171f1-aa5f-4434-b0cd-90a8bedeb4af") },
                new Section { Id = new Guid("38DC4132-780D-4FC1-8F66-1BADBD06E6F5"), Number = 2, VenueId = new Guid("c82171f1-aa5f-4434-b0cd-90a8bedeb4af") });
        }

        private void SeedRow(EventsDBContext context)
        {
            context.Rows.AddRange(
                new Row { Id = new Guid("3eb84460-8144-4340-9577-5c4d3c90f532"), Number = 1, SectionId = new Guid("B6A3C9E9-B7F5-425D-A716-D2D7F788F423") },
                new Row { Id = new Guid("6013c720-74c8-4285-bfe4-e7104890f7fa"), Number = 2, SectionId = new Guid("B6A3C9E9-B7F5-425D-A716-D2D7F788F423") },
                new Row { Id = new Guid("ed7b3f11-4a85-446f-b5e0-679033f0b0a1"), Number = 1, SectionId = new Guid("38DC4132-780D-4FC1-8F66-1BADBD06E6F5") });
        }

        private void SeedSeat(EventsDBContext context)
        {
            context.Seats.AddRange(
                new Seat { Id = new Guid("9553dfdd-34cf-4a1b-a9fd-98f6c282fe46"), Number = 1, RowId = new Guid("3eb84460-8144-4340-9577-5c4d3c90f532") },
                new Seat { Id = new Guid("38862315-7946-499c-a4e8-1dae5221a6fd"), Number = 2, RowId = new Guid("3eb84460-8144-4340-9577-5c4d3c90f532") },
                new Seat { Id = new Guid("f0b63081-812f-4901-8016-422ef2437cc9"), Number = 3, RowId = new Guid("3eb84460-8144-4340-9577-5c4d3c90f532") },
                new Seat { Id = new Guid("f137e8cc-b2ba-48ce-9573-53c9559f006f"), Number = 1, RowId = new Guid("6013c720-74c8-4285-bfe4-e7104890f7fa") },
                new Seat { Id = new Guid("a336f3aa-f729-45c3-83be-db6825482152"), Number = 2, RowId = new Guid("6013c720-74c8-4285-bfe4-e7104890f7fa") },
                new Seat { Id = new Guid("2d803fe6-255b-418a-9b1d-acd9e97f7dba"), Number = 1, RowId = new Guid("ed7b3f11-4a85-446f-b5e0-679033f0b0a1") },
                new Seat { Id = new Guid("2eeafcb1-08ad-4ef1-8ce9-89234c3dd251"), Number = 2, RowId = new Guid("ed7b3f11-4a85-446f-b5e0-679033f0b0a1") });
        }

        private void SeedActivity(EventsDBContext context)
        {
            context.Activities.AddRange(
                new Activity { Id = new Guid("8B5FA894-DFCF-4BB4-A605-5F99985C3805"), Name = "Ram", VenueId = new Guid("c82171f1-aa5f-4434-b0cd-90a8bedeb4af") },
                new Activity { Id = new Guid("7933E0D3-4905-4D2C-B9A1-C20EAD197883"), Name = "Circus", VenueId = new Guid("ef0716cb-54d8-4ddb-8d25-b2a8cb61f026") });
        }

        private void SeedActivityOffer(EventsDBContext context)
        {
            context.ActivityOffers.AddRange(
                new ActivityOffer { Id = new Guid("cee58eef-219c-4551-9031-4ae68a17dd8b"), ActivityId = new Guid("8B5FA894-DFCF-4BB4-A605-5F99985C3805"), PriceType = PriceType.Child, Amount = 250 },
                new ActivityOffer { Id = new Guid("53e2569d-3ea4-4b47-9480-46952765c0c9"), ActivityId = new Guid("8B5FA894-DFCF-4BB4-A605-5F99985C3805"), PriceType = PriceType.Adult, Amount = 500 },
                new ActivityOffer { Id = new Guid("440f0129-8982-4c77-97e9-76cd3efa67d0"), ActivityId = new Guid("8B5FA894-DFCF-4BB4-A605-5F99985C3805"), PriceType = PriceType.VIP, Amount = 800 },
                new ActivityOffer { Id = new Guid("630dd83c-78f3-4e84-b2dd-01bbc52093bd"), ActivityId = new Guid("7933E0D3-4905-4D2C-B9A1-C20EAD197883"), PriceType = PriceType.Child, Amount = 50.5 },
                new ActivityOffer { Id = new Guid("edafbcfe-d72b-4b31-89ad-47cff341b8ee"), ActivityId = new Guid("7933E0D3-4905-4D2C-B9A1-C20EAD197883"), PriceType = PriceType.Adult, Amount = 100.5 },
                new ActivityOffer { Id = new Guid("6b0514ab-1eac-41cd-89b5-f4d0660789b7"), ActivityId = new Guid("7933E0D3-4905-4D2C-B9A1-C20EAD197883"), PriceType = PriceType.VIP, Amount = 200.3 });
        }

        private void SeedActivitySeat(EventsDBContext context)
        {
            context.ActivitySeats.AddRange(
                new ActivitySeat { Id = new Guid("28eeaa98-3068-4a7a-8b6e-4457d81d5312"), SeatId = new Guid("9553dfdd-34cf-4a1b-a9fd-98f6c282fe46"), ActivityId = new Guid("8B5FA894-DFCF-4BB4-A605-5F99985C3805"), State = SeatState.Available, Version = GenerateMockVersion() },
                new ActivitySeat { Id = new Guid("d4016119-36b7-459a-a79f-534f5d69efb3"), SeatId = new Guid("38862315-7946-499c-a4e8-1dae5221a6fd"), ActivityId = new Guid("8B5FA894-DFCF-4BB4-A605-5F99985C3805"), State = SeatState.Available },
                new ActivitySeat { Id = new Guid("433cf7f1-ca84-46fe-9eed-d33124b84acd"), SeatId = new Guid("f0b63081-812f-4901-8016-422ef2437cc9"), ActivityId = new Guid("8B5FA894-DFCF-4BB4-A605-5F99985C3805"), State = SeatState.Available },
                new ActivitySeat { Id = new Guid("194b2efc-02c8-45ab-a375-408e65f30c4a"), SeatId = new Guid("f137e8cc-b2ba-48ce-9573-53c9559f006f"), ActivityId = new Guid("8B5FA894-DFCF-4BB4-A605-5F99985C3805"), State = SeatState.Available },
                new ActivitySeat { Id = new Guid("c85d23cd-61e9-476b-b177-f64ed29dc0d5"), SeatId = new Guid("a336f3aa-f729-45c3-83be-db6825482152"), ActivityId = new Guid("8B5FA894-DFCF-4BB4-A605-5F99985C3805"), State = SeatState.Available },
                new ActivitySeat { Id = new Guid("5928bf55-e20a-418c-9835-d94dba6fb95d"), SeatId = new Guid("2d803fe6-255b-418a-9b1d-acd9e97f7dba"), ActivityId = new Guid("8B5FA894-DFCF-4BB4-A605-5F99985C3805"), State = SeatState.Available },
                new ActivitySeat { Id = new Guid("69971097-4471-4175-ac39-e6d5f5dbfc07"), SeatId = new Guid("2eeafcb1-08ad-4ef1-8ce9-89234c3dd251"), ActivityId = new Guid("8B5FA894-DFCF-4BB4-A605-5F99985C3805"), State = SeatState.Available });
        }

        private void SeedActivitySeatOffer(EventsDBContext context)
        {
            context.ActivitySeatOffers.AddRange(
                new ActivitySeatOffer { Id = new Guid("7c0c96fb-1a79-49c3-837e-21992973603f"), ActivitySeatId = new Guid("28eeaa98-3068-4a7a-8b6e-4457d81d5312"), ActivityOfferId = new Guid("cee58eef-219c-4551-9031-4ae68a17dd8b") },
                new ActivitySeatOffer { Id = new Guid("a45516ba-9bd0-43d5-a591-284c34fe914b"), ActivitySeatId = new Guid("d4016119-36b7-459a-a79f-534f5d69efb3"), ActivityOfferId = new Guid("cee58eef-219c-4551-9031-4ae68a17dd8b") },
                new ActivitySeatOffer { Id = new Guid("d59b9cc7-efae-4c7f-9349-865127dd7bfb"), ActivitySeatId = new Guid("433cf7f1-ca84-46fe-9eed-d33124b84acd"), ActivityOfferId = new Guid("cee58eef-219c-4551-9031-4ae68a17dd8b") },
                new ActivitySeatOffer { Id = new Guid("e6b4879e-947d-46d9-8189-c6a820d1ff8a"), ActivitySeatId = new Guid("194b2efc-02c8-45ab-a375-408e65f30c4a"), ActivityOfferId = new Guid("53e2569d-3ea4-4b47-9480-46952765c0c9") },
                new ActivitySeatOffer { Id = new Guid("6a1adaa4-3cd9-417f-ae02-53a5f2887e81"), ActivitySeatId = new Guid("c85d23cd-61e9-476b-b177-f64ed29dc0d5"), ActivityOfferId = new Guid("53e2569d-3ea4-4b47-9480-46952765c0c9") },
                new ActivitySeatOffer { Id = new Guid("6a2ed8c8-61c3-4de7-a840-6e79011f481c"), ActivitySeatId = new Guid("5928bf55-e20a-418c-9835-d94dba6fb95d"), ActivityOfferId = new Guid("440f0129-8982-4c77-97e9-76cd3efa67d0") },
                new ActivitySeatOffer { Id = new Guid("2b6de77f-4970-42e8-b8e6-e1335e870da7"), ActivitySeatId = new Guid("69971097-4471-4175-ac39-e6d5f5dbfc07"), ActivityOfferId = new Guid("440f0129-8982-4c77-97e9-76cd3efa67d0") });
        }

        private byte[] GenerateMockVersion()
        {
            long counter = 1;
            var version = BitConverter.GetBytes(System.Threading.Interlocked.Increment(ref counter));
            return version;
        }
    }
}
