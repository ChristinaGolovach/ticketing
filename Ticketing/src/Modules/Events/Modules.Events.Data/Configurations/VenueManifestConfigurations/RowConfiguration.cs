using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.Events.Data.Entities.VenueManifest;
using Ticketing.Shared.Data;

using static Modules.Events.Data.EventsDBConstants;


namespace Modules.Events.Data.Configurations.VenueManifestConfigurations
{
    public class RowConfiguration : IEntityTypeConfiguration<Row>
    {
        public void Configure(EntityTypeBuilder<Row> builder)
        {
            builder.ToTable(RowTable.TableName);

            builder.BaseEntityConfigure();

            builder.Property(row => row.Number)
                .IsRequired(false);

            builder.HasOne(row => row.Section)
                .WithMany(section => section.Rows)
                .HasForeignKey(row => row.SectionId);

            builder.HasMany(row => row.Seats)
                .WithOne(seat => seat.Row)
                .HasForeignKey(seat => seat.RowId);
        }
    }
}
