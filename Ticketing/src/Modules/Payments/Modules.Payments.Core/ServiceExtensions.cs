using Microsoft.Extensions.DependencyInjection;
using Modules.Payments.Core.Mapping;

namespace Modules.Payments.Core
{
    public static class ServiceExtensions
    {
        public static void AddPaymentCore(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<MappingProfiles>();
            });
        }
    }
}
