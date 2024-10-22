using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.Events.Data.Entities.VenueManifest;
using Ticketing.Shared.Infrastructure.Data;

using static Modules.Events.Infrastructure.Data.EventsDBConstants;

namespace Modules.Events.Infrastructure.Data.Configurations.VenueManifestConfigurations
{
    public class SeatConfiguration : IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            builder.ToTable(SeatTable.TableName);

            builder.BaseEntityConfigure();

            builder.Property(seat => seat.Number)
                .IsRequired(false);

            builder.HasOne(seat => seat.Row)
                .WithMany(row => row.Seats)
                .HasForeignKey(seat => seat.RowId);

            builder.HasMany(seat => seat.ActivitySeats)
                .WithOne(activitySeat=> activitySeat.Seat)
                .HasForeignKey(activitySeat => activitySeat.SeatId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
