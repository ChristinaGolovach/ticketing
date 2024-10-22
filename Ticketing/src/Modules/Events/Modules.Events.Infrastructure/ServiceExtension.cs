using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modules.Events.Infrastructure.Data;

namespace Modules.Events.Infrastructure
{
    public static class ServicesExtensions
    {
        public static void AddEventsInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EventsDBContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString(EventsDBConstants.DBConnectionKey));
            });
        }
    }
}
