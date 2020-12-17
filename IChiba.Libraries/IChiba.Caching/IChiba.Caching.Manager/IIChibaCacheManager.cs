using EasyCaching.Core;
using System;
using System.Threading.Tasks;

namespace IChiba.Caching
{
    /// <summary>
    /// Default - Hybrid: Local cache & Redis cache
    /// </summary>
    public partial interface IIChibaCacheManager
    {
        /// <summary>
        /// Nếu Get Cache fail thì sẽ lấy dữ liệu từ Database (Local > Redis > Database)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="acquirer"></param>
        /// <param name="cacheTime"></param>
        /// <returns></returns>
        T GetToDb<T>(string key, Func<T> acquirer, int? cacheTime = null);

        /// <summary>
        /// Nếu Get Cache fail thì sẽ lấy dữ liệu từ Database (Local > Redis > Database)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="acquirer"></param>
        /// <param name="cacheTime"></param>
        /// <returns></returns>
        Task<T> GetToDbAsync<T>(string key, Func<Task<T>> acquirer, int? cacheTime = null);

        #region Không dùng, để đồng bộ Cache qua HybridProvider
        //IEasyCachingProvider InMemoryProvider { get; }

        //IEasyCachingProvider RedisProvider { get; }
        //IRedisCachingProvider RedisProvider { get; }
        #endregion

        IHybridCachingProvider HybridProvider { get; }
    }
}
