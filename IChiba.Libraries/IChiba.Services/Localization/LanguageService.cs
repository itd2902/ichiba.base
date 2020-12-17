using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using IChiba.Caching;
using IChiba.Core;
using IChiba.Core.Domain.Master;
using IChiba.Core.Infrastructure;
using IChiba.Data;
using IChiba.Services.Events;

namespace IChiba.Services.Localization
{
    /// <summary>
    /// Language service
    /// </summary>
    public partial class LanguageService : ILanguageService
    {
        #region Fields

        private readonly IEventPublisher _eventPublisher;
        private readonly IRepository<Language> _languageRepository;
        private readonly IIChibaCacheManager _cacheManager;

        #endregion

        #region Ctor

        public LanguageService(
            IEventPublisher eventPublisher,
            IIChibaCacheManager cacheManager)
        {
            _eventPublisher = eventPublisher;
            _languageRepository = EngineContext.Current.Resolve<IRepository<Language>>(DataConnectionHelper.ConnectionStringNames.Master); ;
            _cacheManager = cacheManager;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Deletes a language
        /// </summary>
        /// <param name="language">Language</param>
        public virtual void DeleteLanguage(Language language)
        {
            if (language == null)
                throw new ArgumentNullException(nameof(language));

            _languageRepository.Delete(language);

            //event notification
            _eventPublisher.EntityDeleted(language);
        }

        /// <summary>
        /// Gets all languages
        /// </summary>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Languages</returns>
        public virtual IList<Language> GetAllLanguages(bool showHidden = false)
        {
            var query = _languageRepository.Table;
            if (!showHidden) query = query.Where(l => l.Published);
            query = query.OrderBy(l => l.DisplayOrder).ThenBy(l => l.Id);

            //cacheable copy
            var key = LocalizationCacheKeys.LanguagesAllCacheKey.FormatWith(showHidden);

            var languages = _cacheManager.GetToDb(key, () =>
            {
                var allLanguages = query.ToList();

                return allLanguages;
            }, CachingDefaults.MonthCacheTime);

            return languages;
        }

        /// <summary>
        /// Gets a language
        /// </summary>
        /// <param name="languageId">Language identifier</param>
        /// <returns>Language</returns>
        public virtual Language GetLanguageById(int languageId)
        {
            if (languageId == 0)
                return null;

            var key = BaseEntity.GetEntityCacheKey(typeof(Language), languageId);
            return _cacheManager.GetToDb(key, () => _languageRepository.GetById(languageId));
        }

        /// <summary>
        /// Inserts a language
        /// </summary>
        /// <param name="language">Language</param>
        public virtual void InsertLanguage(Language language)
        {
            if (language == null)
                throw new ArgumentNullException(nameof(language));

            _languageRepository.Insert(language);

            //event notification
            _eventPublisher.EntityInserted(language);
        }

        /// <summary>
        /// Updates a language
        /// </summary>
        /// <param name="language">Language</param>
        public virtual void UpdateLanguage(Language language)
        {
            if (language == null)
                throw new ArgumentNullException(nameof(language));

            //update language
            _languageRepository.Update(language);

            //event notification
            _eventPublisher.EntityUpdated(language);
        }

        /// <summary>
        /// Get 2 letter ISO language code
        /// </summary>
        /// <param name="language">Language</param>
        /// <returns>ISO language code</returns>
        public virtual string GetTwoLetterIsoLanguageName(Language language)
        {
            if (language == null)
                throw new ArgumentNullException(nameof(language));

            if (string.IsNullOrEmpty(language.LanguageCulture))
                return "en";

            var culture = new CultureInfo(language.LanguageCulture);
            var code = culture.TwoLetterISOLanguageName;

            return string.IsNullOrEmpty(code) ? "en" : code;
        }

        public virtual Language GetDefaultLanguage()
        {
            var languages = GetAllLanguages(true);
            if (!languages.Any())
                return null;

            var language = languages
                .Where(w => w.Published)
                .OrderBy(o => o.DisplayOrder)
                .FirstOrDefault()
                ??
                languages
                .OrderBy(o => o.DisplayOrder)
                .FirstOrDefault();

            return language;
        }

        #endregion
    }
}
