using Microsoft.EntityFrameworkCore;
using Modules.Users.Data.Entities;

namespace Modules.Users.Data
{
    public class UsersDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UsersDBContext(DbContextOptions<UsersDBContext> options) : base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(UsersDBConstants.SchemaName);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
