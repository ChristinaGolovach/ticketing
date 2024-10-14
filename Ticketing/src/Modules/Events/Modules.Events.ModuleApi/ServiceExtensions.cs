using Microsoft.Extensions.DependencyInjection;

namespace Modules.Events.ModuleApi
{
    public static class ServiceExtensions
    {
        public static void AddEventModuleApi(this IServiceCollection services)
        {
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(typeof(ServiceExtensions).Assembly);
            });
        }
    }
}
