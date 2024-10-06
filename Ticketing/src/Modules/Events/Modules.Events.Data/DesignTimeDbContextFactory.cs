using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Modules.Events.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EventsDBContext>
    {
        public EventsDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EventsDBContext>();
            //var connectionString = args[0];
            //optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.UseSqlServer("Server=localhost;Database=Ticketing; Integrated Security=True;TrustServerCertificate=True;");

            return new EventsDBContext(optionsBuilder.Options);
        }
    }
}
