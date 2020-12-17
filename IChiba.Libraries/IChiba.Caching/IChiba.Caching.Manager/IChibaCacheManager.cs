using EasyCaching.Core;
using System;
using System.Threading.Tasks;

namespace IChiba.Caching
{
    public partial class IChibaCacheManager : IIChibaCacheManager
    {
        public IHybridCachingProvider HybridProvider { get; }

        public IChibaCacheManager(
            IHybridCachingProvider hybridProvider)
        {
            HybridProvider = hybridProvider;
        }

        public virtual T GetToDb<T>(string key, Func<T> acquirer, int? cacheTime = null)
        {
            var duration = cacheTime.HasValue && cacheTime.Value > 0
                ? TimeSpan.FromMinutes(cacheTime.Value)
                : TimeSpan.FromMinutes(CachingDefaults.CacheTime);
            var cacheValue = HybridProvider.Get(key, acquirer, duration);
            if (cacheValue.HasValue)
                return cacheValue.Value;

            var result = acquirer();
            return result;
        }

        public virtual async Task<T> GetToDbAsync<T>(string key, Func<Task<T>> acquirer, int? cacheTime = null)
        {
            var duration = cacheTime.HasValue && cacheTime.Value > 0
                ? TimeSpan.FromMinutes(cacheTime.Value)
                : TimeSpan.FromMinutes(CachingDefaults.CacheTime);
            var cacheValue = await HybridProvider.GetAsync(key, acquirer, duration);
            if (cacheValue.HasValue)
                return cacheValue.Value;

            var result = await acquirer();
            return result;
        }
    }
}
