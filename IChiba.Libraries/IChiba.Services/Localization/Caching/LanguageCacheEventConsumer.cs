using IChiba.Caching;
using IChiba.Core.Domain.Master;
using IChiba.Core.Infrastructure;
using IChiba.Services.Caching;

namespace IChiba.Services.Localization.Caching
{
    /// <summary>
    /// Represents a language cache event consumer
    /// </summary>
    public partial class LanguageCacheEventConsumer : CacheEventConsumer<Language>
    {
        public LanguageCacheEventConsumer()
            : base(EngineContext.Current.Resolve<IIChibaCacheManager>())
        {

        }

        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected override void ClearCache(Language entity)
        {
            Remove(LocalizationCacheKeys.LocaleStringResourcesAllPublicCacheKey.FormatWith(entity.Id));
            Remove(LocalizationCacheKeys.LocaleStringResourcesAllAdminCacheKey.FormatWith(entity.Id));
            Remove(LocalizationCacheKeys.LocaleStringResourcesAllCacheKey.FormatWith(entity.Id));

            var prefix = LocalizationCacheKeys.LocaleStringResourcesByResourceNamePrefixCacheKey.FormatWith(entity);
            RemoveByPrefix(prefix);

            RemoveByPrefix(LocalizationCacheKeys.LanguagesAllPrefixCacheKey);
        }
    }
}
