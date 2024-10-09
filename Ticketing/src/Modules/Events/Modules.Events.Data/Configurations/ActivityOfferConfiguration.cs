using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.Events.Data.Entities;
using Ticketing.Shared.Data;

using static Modules.Events.Data.EventsDBConstants;

namespace Modules.Events.Data.Configurations
{
    public class ActivityOfferConfiguration : IEntityTypeConfiguration<ActivityOffer>
    {
        public void Configure(EntityTypeBuilder<ActivityOffer> builder) 
        {
            builder.ToTable(ActivityOfferTable.TableName);

            builder.BaseEntityConfigure();

            builder.Property(activityOffer => activityOffer.PriceType)
                .IsRequired();

            builder.Property(activityOffer => activityOffer.Amount)
                .IsRequired();

            builder.HasOne(activityOffer => activityOffer.Activity)
                .WithMany(activity => activity.ActivityOffers)
                .HasForeignKey(activityOffer => activityOffer.ActivityId);

            builder.HasMany(activityOffer => activityOffer.ActivitySeatOffers)
                .WithOne(activitySeatOffer => activitySeatOffer.ActivityOffer)
                .HasForeignKey(activitySeatOffer => activitySeatOffer.ActivityOfferId);
        }
    }
}
