using Microsoft.Extensions.DependencyInjection;
using Modules.Events.Core;
using Modules.Events.Core.Services;

namespace Modules.Events.Api
{
    public static class ServiceExtensions
    {
        public static void AddEventApi(this IServiceCollection services)
        {
            services.AddControllers()
                .AddApplicationPart(typeof(ServiceExtensions).Assembly);


            services.AddTransient<IActivityService, ActivityService>();
            services.AddTransient<IActivitySeatService, ActivitySeatService>();
            services.AddTransient<IVenueService, VenueService>();

            services.AddEventCore();
        }
    }
}
