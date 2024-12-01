using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Ticketing.Shared.Infrastructure.Bus;
using Ticketing.Shared.Infrastructure.Cache;

namespace Ticketing.Shared.Infrastructure
{
    public static class ServiceExtensions
    {
        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetConnectionString("RedisCache");
            });

            services.AddSingleton<ICacheService, CacheService>();

            services.Configure<BusConfigurations>(configuration.GetSection(nameof(BusConfigurations)));

            services.AddSingleton(serviceProvider =>
            {
                var options = serviceProvider.GetService<IOptions<BusConfigurations>>().Value;
                return new ServiceBusClient(options.ConnectionString, options.GetClientOptions());
            });

            services.AddSingleton<IBusService, BusService>();
        }
    }
}
