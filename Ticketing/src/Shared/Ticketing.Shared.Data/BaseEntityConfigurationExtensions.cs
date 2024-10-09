using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ticketing.Shared.Data
{
    public static class BaseEntityConfigurationExtensions
    {
        public static EntityTypeBuilder<TEntity> BaseEntityConfigure<TEntity>(this EntityTypeBuilder<TEntity> builder)
            where TEntity : BaseEntity
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.HasKey(entity => entity.Id);

            builder.Property(entity => entity.Created)
                .IsRequired();

            builder.Property(entity => entity.Updated)
                .IsRequired();

            builder.Property(entity => entity.Deleted)
                .HasDefaultValue(false)
                .IsRequired();

            return builder;
        }
    }
}
