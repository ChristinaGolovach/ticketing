using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Modules.Orders.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<OrdersDBContext>
    {
        public OrdersDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OrdersDBContext>();
            //var connectionString = args[0];
            //optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.UseSqlServer("Server=localhost;Database=Ticketing; Integrated Security=True;TrustServerCertificate=True;");

            return new OrdersDBContext(optionsBuilder.Options);
        }
    }
}
