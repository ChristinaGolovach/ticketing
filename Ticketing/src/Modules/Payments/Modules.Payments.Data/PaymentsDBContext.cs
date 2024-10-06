using Microsoft.EntityFrameworkCore;
using Modules.Payments.Data.Entities;

namespace Modules.Payments.Data
{
    public class PaymentsDBContext : DbContext
    {
        public DbSet<Payment> Payments { get; set; }
        public PaymentsDBContext(DbContextOptions<PaymentsDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(PaymentsDBConstants.SchemaName);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
