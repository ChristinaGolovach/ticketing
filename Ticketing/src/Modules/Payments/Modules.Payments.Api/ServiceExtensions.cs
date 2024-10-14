using Microsoft.Extensions.DependencyInjection;
using Modules.Payments.Core;
using Modules.Payments.Core.Services;


namespace Modules.Payments.Api
{
    public static class ServiceExtensions
    {
        public static void AddPaymentApi(this IServiceCollection services)
        {
            services.AddControllers()
                .AddApplicationPart(typeof(ServiceExtensions).Assembly);

            services.AddScoped<IPaymentService, PaymentService>();

            services.AddPaymentCore();
        }

    }
}
