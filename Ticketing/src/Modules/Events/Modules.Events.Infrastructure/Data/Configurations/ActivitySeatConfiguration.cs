using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.Events.Data.Entities;
using Ticketing.Shared.Infrastructure.Data;

using static Modules.Events.Infrastructure.Data.EventsDBConstants;

namespace Modules.Events.Infrastructure.Data.Configurations
{
    public class ActivitySeatConfiguration: IEntityTypeConfiguration<ActivitySeat>
    {
        public void Configure(EntityTypeBuilder<ActivitySeat> builder)
        {
            builder.ToTable(ActivitySeatTable.TableName);

            builder.BaseEntityConfigure();

            builder.Property(entity => entity.Version)
                .IsRowVersion();

            builder.Property(activitySeat => activitySeat.State)
                .IsRequired()
                .HasDefaultValue(SeatState.Available);

            builder.HasOne(activitySeat => activitySeat.Seat)
                .WithMany(seat => seat.ActivitySeats)
                .HasForeignKey(activitySeat => activitySeat.SeatId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(activitySeat => activitySeat.Activity)
                .WithMany(activity => activity.ActivitySeats)
                .HasForeignKey(activitySeat => activitySeat.ActivityId);

        }
    }
}
