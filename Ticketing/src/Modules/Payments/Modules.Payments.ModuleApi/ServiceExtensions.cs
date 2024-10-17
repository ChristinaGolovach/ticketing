using Microsoft.Extensions.DependencyInjection;

namespace Modules.Payments.ModuleApi
{
    public static class ServiceExtensions
    {
        public static void AddPaymentModuleApi(this IServiceCollection services)
        {
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(typeof(ServiceExtensions).Assembly);
            });
        }
    }
}
