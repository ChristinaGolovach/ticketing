using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TicketingIntegrationTests.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static void ReplaceDbContext<TContext>(this IServiceCollection services, Action<DbContextOptionsBuilder> configure)
            where TContext : DbContext
        {
            var dbContextServiceDescriptor =
                services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<TContext>));

            if (dbContextServiceDescriptor != null)
            {
                services.Remove(dbContextServiceDescriptor);
                services.AddDbContext<TContext>(configure);
            };
        }
    }
}
