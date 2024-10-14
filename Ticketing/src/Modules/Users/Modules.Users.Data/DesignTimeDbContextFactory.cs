using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Modules.Users.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<UsersDBContext>
    {
        public UsersDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<UsersDBContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=Ticketing; Integrated Security=True;TrustServerCertificate=True;");

            return new UsersDBContext(optionsBuilder.Options);
        }
    }
}
