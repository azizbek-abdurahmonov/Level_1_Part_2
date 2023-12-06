using Force.DeepCloner;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using N80_HT1.Caching.Interfaces;
using N80_HT1.Common.Models;
using N80_HT1.Settings;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace N80_HT1.Caching;

public class RedisCacheBroker(IOptions<CacheSettings> cacheOptions, IDistributedCache distributedCache) : ICacheBroker
{
    private readonly DistributedCacheEntryOptions _entryOptions = new()
    {
        AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(cacheOptions.Value.AbsoluteExpirationTimeInSeconds),
        SlidingExpiration = TimeSpan.FromSeconds(cacheOptions.Value.SlidingExpirationTimeInSeconds)
    };

    public async ValueTask DeleteAsync(string key, CancellationToken cancellationToken = default)
    {
        await distributedCache.RemoveAsync(key, cancellationToken);
    }

    public async ValueTask<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default)
    {
        var value = await distributedCache.GetStringAsync(key, cancellationToken);

        return value is not null ? JsonSerializer.Deserialize<T>(value) : default;
    }

    public async ValueTask<T?> GetOrSetAsync<T>(string key, Func<Task<T>> valueFactory, CacheEntryOptions? entryOptions = null, CancellationToken cancellationToken = default)
    {
        var cachedValue = await distributedCache.GetStringAsync(key, cancellationToken);
        if (cachedValue is not null) return JsonSerializer.Deserialize<T>(cachedValue);

        var value = await valueFactory();
        await distributedCache.SetStringAsync(key, JsonSerializer.Serialize(value), GetCacheEntryOptions(entryOptions), cancellationToken);

        return value;
    }

    public async ValueTask SetAsync<T>(string key, T value, CacheEntryOptions? entryOptions = null, CancellationToken cancellationToken = default)
    {
        var cachedValue = await distributedCache.GetStringAsync(key, cancellationToken);

        if (cachedValue is not null)
            await DeleteMultipleEntitiesAsync(typeof(T));

        await distributedCache.SetStringAsync(key, JsonSerializer.Serialize(value), GetCacheEntryOptions(entryOptions), cancellationToken);
    }


    public async ValueTask SetMultipleAsync<T>(string key, T value, CacheEntryOptions? cacheEntry = null, CancellationToken cancellationToken = default)
    {
        await distributedCache.SetStringAsync(key, JsonSerializer.Serialize(value), GetCacheEntryOptions(cacheEntry), cancellationToken);

        var multipleEntitiesKeysKey = $"{typeof(T).Name}s".ToLower();
        var cachedEntitiesKeys = await distributedCache.GetStringAsync(multipleEntitiesKeysKey);
        List<string> multipleEntitiesKeys;

        if (cachedEntitiesKeys is not null)
        {
            multipleEntitiesKeys = JsonSerializer.Deserialize<List<string>>(cachedEntitiesKeys)
                ?? throw new InvalidOperationException();

            multipleEntitiesKeys.Add(key);
            await distributedCache.SetStringAsync(multipleEntitiesKeysKey, JsonSerializer.Serialize(multipleEntitiesKeys), token: cancellationToken);
        }
        else
        {
            multipleEntitiesKeys = new List<string> { key };
            await distributedCache.SetStringAsync(multipleEntitiesKeysKey, JsonSerializer.Serialize(multipleEntitiesKeys), token: cancellationToken);
        }
    }

    public ValueTask<bool> TryGetAsync<T>(string key, out T? value)
    {
        var cachedValue = distributedCache.GetString(key);

        if (cachedValue is not null)
        {
            value = JsonSerializer.Deserialize<T>(cachedValue);
            return ValueTask.FromResult(true);
        }

        value = default;
        return ValueTask.FromResult(false);
    }

    private DistributedCacheEntryOptions GetCacheEntryOptions(CacheEntryOptions? entryOptions)
    {
        if (entryOptions == default || (!entryOptions.AbsoluteExpirationRelativeToNow.HasValue && !entryOptions.SlidingExpiration.HasValue))
            return _entryOptions;


        var currentEntryOptions = _entryOptions.DeepClone();

        currentEntryOptions.AbsoluteExpirationRelativeToNow = entryOptions.AbsoluteExpirationRelativeToNow;
        currentEntryOptions.SlidingExpiration = entryOptions.SlidingExpiration;

        return currentEntryOptions;
    }

    private async ValueTask DeleteMultipleEntitiesAsync(Type type)
    {
        var keysKey = type.Name + "s";
        List<string>? cachedEntitiesKeys;

        var cachedValue = await distributedCache.GetStringAsync(keysKey)
            ?? throw new InvalidOperationException("");

        cachedEntitiesKeys = JsonSerializer.Deserialize<List<string>>(cachedValue)
            ?? throw new InvalidOperationException();

        cachedEntitiesKeys.ForEach(key => distributedCache.Remove(key));

        await distributedCache.SetStringAsync(keysKey, JsonSerializer.Serialize(new List<string>()));
    }
}
