using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.Events.Data.Entities.VenueManifest;
using Ticketing.Shared.Infrastructure.Data;

using static Modules.Events.Infrastructure.Data.EventsDBConstants;

namespace Modules.Events.Infrastructure.Data.Configurations.VenueManifestConfigurations
{
    public class VenueConfiguration : IEntityTypeConfiguration<Venue>
    {
        public void Configure(EntityTypeBuilder<Venue> builder)
        {
            builder.ToTable(VenueTable.TableName);

            builder.BaseEntityConfigure();

            builder.Property(venue => venue.Name)
                .IsRequired()
                .HasMaxLength(VenueTable.StringMaxLength);

            builder.Property(venue => venue.Country)
                .IsRequired()
                .HasMaxLength(VenueTable.StringMaxLength);

            builder.Property(venue => venue.City)
                .IsRequired()
                .HasMaxLength(VenueTable.StringMaxLength);

            builder.Property(venue => venue.Street)
                .IsRequired()
                .HasMaxLength(VenueTable.StringMaxLength);

            builder.Property(venue => venue.BuildNumber)
                .IsRequired()
                .HasMaxLength(VenueTable.StringMaxLength);

            builder.HasMany(venue => venue.Activities)
                .WithOne(activity => activity.Venue)
                .HasForeignKey(activity => activity.VenueId);

            builder.HasMany(venue => venue.Sections)
                .WithOne(section => section.Venue)
                .HasForeignKey(section => section.VenueId);
        }
    }
}
