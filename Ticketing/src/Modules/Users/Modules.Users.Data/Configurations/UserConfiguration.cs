using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.Users.Data.Entities;
using Ticketing.Shared.Infrastructure.Data;
using static Modules.Users.Data.UsersDBConstants;


namespace Modules.Users.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(UserTable.TableName);

            builder.BaseEntityConfigure();

            builder.Property(user => user.FirstName)
                .HasMaxLength(UserTable.StringMaxLength)
                .IsRequired();

            builder.Property(user => user.LastName)
                .HasMaxLength(UserTable.StringMaxLength)
                .IsRequired();

            builder.Property(user => user.Email)
                .HasMaxLength(UserTable.EmailMaxLength)
                .IsRequired();

            builder.HasIndex(user => user.Email)
                .IsUnique();
        }
    }
}
