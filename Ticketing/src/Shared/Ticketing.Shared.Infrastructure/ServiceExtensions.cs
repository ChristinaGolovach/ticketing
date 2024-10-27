using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
        }
    }
}
