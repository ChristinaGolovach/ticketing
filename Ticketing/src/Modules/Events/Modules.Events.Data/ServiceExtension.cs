using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ticketing.Shared.Data.Repository;

namespace Modules.Events.Data
{
    public static class ServicesExtensions
    {
        public static void AddEventData(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EventsDBContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString(EventsDBConstants.DBConnectionKey));
            });

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
