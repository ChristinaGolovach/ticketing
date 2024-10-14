using Microsoft.Extensions.DependencyInjection;
using Modules.Orders.Core.Services;

namespace Modules.Orders.Api
{
    public static class ServiceExtensions
    {
        public static void AddOrderApi(this IServiceCollection services)
        {
            services.AddControllers()
                .AddApplicationPart(typeof(ServiceExtensions).Assembly);

            services.AddTransient<IOrderService, OrderService>();
        }
    }
}
