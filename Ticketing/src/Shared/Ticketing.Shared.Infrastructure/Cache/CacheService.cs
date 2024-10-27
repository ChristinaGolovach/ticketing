
using Microsoft.Extensions.Caching.Distributed;
using System.Buffers;
using System.Text.Json;

namespace Ticketing.Shared.Infrastructure.Cache
{
    public class CacheService : ICacheService
    {
        private readonly IDistributedCache _cache;

        public CacheService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<T> GetAsync<T>(string cacheKey, CancellationToken cancellationToken = default)
        {
            var cachedItem = await _cache.GetAsync(cacheKey, cancellationToken);

            var item = cachedItem == null
                ? default
                : Deserialize<T>(cachedItem);

            return item;
        }

        public async Task SetAsync<T>(string cacheKey, T value, TimeSpan? expiration = null, CancellationToken cancellationToken = default)
        {
            var bytes = Serialize(value);
            await _cache.SetAsync(cacheKey, bytes, CacheOptions.CustomOptions(expiration), cancellationToken);
        }

        public Task RemoveAsync(string cacheKey, CancellationToken cancellationToken = default)
        {
            return _cache.RemoveAsync(cacheKey, cancellationToken);
        }

        private static T Deserialize<T>(byte[] bytes)
        {
            return JsonSerializer.Deserialize<T>(bytes);
        }

        private static byte[] Serialize<T>(T value)
        {
            var buffer = new ArrayBufferWriter<byte>();
            using (var writer = new Utf8JsonWriter(buffer))
            {
                JsonSerializer.Serialize(writer, value);
            }

            return buffer.WrittenSpan.ToArray();
        }
    }
}
