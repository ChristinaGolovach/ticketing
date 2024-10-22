using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.Events.Data.Entities;
using Ticketing.Shared.Infrastructure.Data;
using static Modules.Events.Infrastructure.Data.EventsDBConstants;

namespace Modules.Events.Infrastructure.Data.Configurations
{
    public class ActivitySeatOfferConfiguration : IEntityTypeConfiguration<ActivitySeatOffer>
    {
        public void Configure(EntityTypeBuilder<ActivitySeatOffer> builder) 
        {
            builder.ToTable(ActivitySeatOfferTable.TableName);

            builder.BaseEntityConfigure();

            builder.HasOne(activitySeatOffer => activitySeatOffer.ActivitySeat)
                .WithOne(activitySeat => activitySeat.ActivitySeatOffer)
                .HasForeignKey<ActivitySeatOffer>(activitySeatOffer => activitySeatOffer.ActivitySeatId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(activitySeatOffer => activitySeatOffer.ActivityOffer)
                .WithMany(activityOffer => activityOffer.ActivitySeatOffers)
                .HasForeignKey(activitySeatOffer => activitySeatOffer.ActivityOfferId);
        }
    }
}
