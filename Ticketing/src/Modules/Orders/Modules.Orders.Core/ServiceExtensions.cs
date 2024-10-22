using Microsoft.Extensions.DependencyInjection;
using Modules.Orders.Core.Mappings;

namespace Modules.Orders.Core
{
    public static class ServiceExtensions
    {
        public static void AddOrderCore(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<MappingProfiles>();
            });
        }
    }
}
