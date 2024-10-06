using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Modules.Events.Data
{
    public static class ServicesExtensions
    {
        public static void AddEventData(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EventsDBContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString(EventsDBConstants.DBConnectionKey));
            });

            //services.AddScoped<IHistoryRepository<EventArgs>, >
        }
    }
}
