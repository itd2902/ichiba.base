using IChiba.Caching;
using IChiba.Core.Domain.Master;
using IChiba.Core.Infrastructure;
using IChiba.Services.Caching;

namespace IChiba.Services.Localization.Caching
{
    /// <summary>
    /// Represents a locale string resource cache event consumer
    /// </summary>
    public partial class LocaleStringResourceCacheEventConsumer : CacheEventConsumer<LocaleStringResource>
    {
        public LocaleStringResourceCacheEventConsumer()
            : base(EngineContext.Current.Resolve<IIChibaCacheManager>())
        {
            
        }

        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(LocaleStringResource entity)
        {
            RemoveByPrefix(LocalizationCacheKeys.LocaleStringResourcesPrefixCacheKey);
        }
    }
}
