using Microsoft.Extensions.DependencyInjection;

namespace Modules.Orders.ModuleApi
{
    public static class ServiceExtensions
    {
        public static void AddOrderModuleApi(this IServiceCollection services)
        {
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(typeof(ServiceExtensions).Assembly);
            });
        }
    }
}
