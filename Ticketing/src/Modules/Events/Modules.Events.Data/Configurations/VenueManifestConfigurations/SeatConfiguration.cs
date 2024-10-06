using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.Events.Data.Entities.VenueManifest;
using Ticketing.Shared.Data;

using static Modules.Events.Data.EventsDBConstants;

namespace Modules.Events.Data.Configurations.VenueManifestConfigurations
{
    public class SeatConfiguration : IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            builder.ToTable(SeatTable.TableName);

            builder.BaseEntityConfigure();

            builder.Property(seat => seat.Number)
                .IsRequired(false);

            builder.Property(seat => seat.State)
                .HasDefaultValue(SeatState.Available)
                .IsRequired();

            builder.HasOne(seat => seat.Row)
                .WithMany(row => row.Seats)
                .HasForeignKey(seat => seat.RowId);

            builder.HasMany(seat => seat.SeatOffers)
                .WithOne(seatOffer => seatOffer.Seat)
                .HasForeignKey(seatOffer => seatOffer.SeatId);
        }
    }
}
