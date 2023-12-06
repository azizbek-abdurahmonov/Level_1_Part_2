using N80_HT1.Common.Models;
using N80_HT1.Settings;

namespace N80_HT1.Caching.Interfaces;

public interface ICacheBroker
{
    ValueTask<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default);

    ValueTask<bool> TryGetAsync<T>(string key, out T? value);

    ValueTask SetMultipleAsync<T>(string key, T value, CacheEntryOptions? cacheEntry = default, CancellationToken cancellationToken = default);

    ValueTask SetAsync<T>(string key, T value, CacheEntryOptions? entryOptions = default, CancellationToken cancellationToken = default);

    ValueTask DeleteAsync(string key, CancellationToken cancellationToken = default);

    ValueTask<T?> GetOrSetAsync<T>(string key, Func<Task<T>> valueFactory, CacheEntryOptions? entryOptions = default, CancellationToken cancellationToken = default);
}
