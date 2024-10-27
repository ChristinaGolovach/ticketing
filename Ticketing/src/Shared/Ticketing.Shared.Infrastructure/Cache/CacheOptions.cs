using Microsoft.Extensions.Caching.Distributed;

namespace Ticketing.Shared.Infrastructure.Cache
{
    public static class CacheOptions
    {
        public static DistributedCacheEntryOptions DefaultOption =>
            new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
            };

        public static DistributedCacheEntryOptions CustomOptions(TimeSpan? expiration)
        {
            return expiration == null
                ? DefaultOption
                : new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = expiration };
        }
    }
}
