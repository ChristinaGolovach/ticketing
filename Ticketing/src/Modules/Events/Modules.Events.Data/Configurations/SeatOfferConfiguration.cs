using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.Events.Data.Entities;
using Ticketing.Shared.Data;
using static Modules.Events.Data.EventsDBConstants;

namespace Modules.Events.Data.Configurations
{
    public class SeatOfferConfiguration : IEntityTypeConfiguration<SeatOffer>
    {
        public void Configure(EntityTypeBuilder<SeatOffer> builder) 
        {
            builder.ToTable(SeatOfferTable.TableName);

            builder.BaseEntityConfigure();

            builder.HasOne(seatOffer => seatOffer.Seat)
                .WithMany(seat => seat.SeatOffers)
                .HasForeignKey(seatOffer => seatOffer.SeatId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            builder.HasOne(seatOffer => seatOffer.ActivityOffer)
                .WithMany(activityOffer => activityOffer.SeatOffers)
                .HasForeignKey(seatOffer => seatOffer.ActivityOfferId);
        }
    }
}
