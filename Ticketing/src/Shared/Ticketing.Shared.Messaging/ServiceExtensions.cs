using Microsoft.Extensions.DependencyInjection;

namespace Ticketing.Shared.Messaging
{
    public static class ServiceExtensions
    {
        public static void AddSharedRequests(this IServiceCollection services)
        {
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(typeof(ServiceExtensions).Assembly);
            });
        }
    }
}
