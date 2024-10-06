using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.Events.Data.Entities;
using Ticketing.Shared.Data;

using static Modules.Events.Data.EventsDBConstants;

namespace Modules.Events.Data.Configurations
{
    public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.ToTable(ActivityTable.TableName);

            builder.BaseEntityConfigure();

            builder.Property(activity => activity.Name)
                .HasMaxLength(ActivityTable.StringMaxLength)
                .IsRequired();

            builder.Property(activity => activity.Date)
                .IsRequired();

            builder.HasOne(activity => activity.Venue)
                .WithMany(venue => venue.Activities)
                .HasForeignKey(activity => activity.VenueId);

            builder.HasMany(activity => activity.ActivityOffers)
                .WithOne(activityOffer => activityOffer.Activity)
                .HasForeignKey(activityOffer => activityOffer.ActivityId);
        }
    }
}
