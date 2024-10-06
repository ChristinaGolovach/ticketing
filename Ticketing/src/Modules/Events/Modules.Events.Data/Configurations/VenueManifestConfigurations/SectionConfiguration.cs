using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.Events.Data.Entities.VenueManifest;
using Ticketing.Shared.Data;

using static Modules.Events.Data.EventsDBConstants;

namespace Modules.Events.Data.Configurations.VenueManifestConfigurations
{
    public class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.ToTable(SectionTable.TableName);

            builder.BaseEntityConfigure();

            builder.Property(section => section.Number)
                .IsRequired();

            builder.HasOne(section => section.Venue)
                .WithMany(venue => venue.Sections)
                .HasForeignKey(section => section.VenueId);

            builder.HasMany(section => section.Rows)
                .WithOne(row => row.Section)
                .HasForeignKey(row => row.SectionId);
        }
    }
}
