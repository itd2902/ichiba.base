using IChiba.Caching;
using IChiba.Core.Domain.Master;
using IChiba.Core.Infrastructure;
using IChiba.Services.Caching;

namespace IChiba.Services.Localization.Caching
{
    /// <summary>
    /// Represents a localized property cache event consumer
    /// </summary>
    public partial class LocalizedPropertyCacheEventConsumer : CacheEventConsumer<LocalizedProperty>
    {
        public LocalizedPropertyCacheEventConsumer()
            : base(EngineContext.Current.Resolve<IIChibaCacheManager>())
        {

        }

        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(LocalizedProperty entity)
        {
            Remove(LocalizationCacheKeys.LocalizedPropertyAllCacheKey);

            var cacheKey = LocalizationCacheKeys.LocalizedPropertyCacheKey.FormatWith(
                entity.LanguageId, entity.EntityId, entity.LocaleKeyGroup, entity.LocaleKey);

            Remove(cacheKey);
        }
    }
}
