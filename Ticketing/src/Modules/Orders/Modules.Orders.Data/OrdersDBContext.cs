using Microsoft.EntityFrameworkCore;
using Modules.Orders.Data.Entities;

namespace Modules.Orders.Data
{
    public class OrdersDBContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public OrdersDBContext(DbContextOptions<OrdersDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(OrdersDBConstants.SchemaName);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
