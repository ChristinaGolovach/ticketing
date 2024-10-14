using Microsoft.Extensions.DependencyInjection;
using Modules.Events.Core.Mappings;

namespace Modules.Events.Core
{
    public static class ServiceExtensions
    {
        public static void AddEventCore(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<MappingProfiles>();
            });
        }
    }
}
