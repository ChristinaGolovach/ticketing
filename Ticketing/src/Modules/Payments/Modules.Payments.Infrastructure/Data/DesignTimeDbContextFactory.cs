using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Modules.Payments.Infrastructure.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<PaymentsDBContext>
    {
        public PaymentsDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PaymentsDBContext>();
            //var connectionString = args[0];
            //optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.UseSqlServer("Server=localhost;Database=Ticketing; Integrated Security=True;TrustServerCertificate=True;");

            return new PaymentsDBContext(optionsBuilder.Options);
        }
    }
}
