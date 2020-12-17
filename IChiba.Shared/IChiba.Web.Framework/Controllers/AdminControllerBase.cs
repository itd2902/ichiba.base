using System;
using System.Collections.Generic;
using System.Linq;
using IChiba.Core;
using IChiba.Core.Infrastructure;
using IChiba.Services.Localization;
using IChiba.Web.Framework.Models;
using Microsoft.AspNetCore.Authorization;

namespace IChiba.Web.Framework.Controllers
{
    [Authorize]
    public abstract class AdminControllerBase : IChibaController
    {
        /// <summary>
        /// Add locales for localizable entities
        /// </summary>
        /// <typeparam name="T">Localizable model</typeparam>
        /// <param name="languageService">Language service</param>
        /// <param name="locales">Locales</param>
        /// <param name="localeLabels">Locale labels</param>
        /// <param name="actionLabels">(labels, languageId)</param>
        protected virtual void AddLocales<T>(ILanguageService languageService, IList<T> locales, IDictionary<string, string> localeLabels,
            Action<IDictionary<string, string>, string> actionLabels)
            where T : ILocalizedLocaleModel
        {
            AddLocales(languageService, locales, localeLabels, actionLabels, null);
        }

        /// <summary>
        /// Add locales for localizable entities
        /// </summary>
        /// <typeparam name="T">Localizable model</typeparam>
        /// <param name="languageService">Language service</param>
        /// <param name="locales">Locales</param>
        /// <param name="localeLabels">Locale labels</param>
        /// <param name="actionLabels">(labels, languageId)</param>
        /// <param name="configure">Configure action (locale, languageId)</param>
        protected virtual void AddLocales<T>(ILanguageService languageService, IList<T> locales, IDictionary<string, string> localeLabels,
            Action<IDictionary<string, string>, string> actionLabels, Action<T, string> configure)
            where T : ILocalizedLocaleModel
        {
            var workContext = EngineContext.Current.Resolve<IWorkContext>();
            var languages = languageService.GetAllLanguages(true);
            var curLanguageId = workContext.LanguageId;
            if (string.IsNullOrWhiteSpace(curLanguageId))
                curLanguageId = languages.FirstOrDefault()?.Id;
            foreach (var language in languages)
            {
                var locale = Activator.CreateInstance<T>();
                locale.LanguageId = language.Id;
                locale._LanguageCode = language.TwoLetterLanguageCode;
                locale._FlagCode = language.TwoLetterCountryCode;
                if (configure != null)
                {
                    configure.Invoke(locale, locale.LanguageId);
                }
                locales.Add(locale);
            }

            actionLabels.Invoke(localeLabels, curLanguageId);
        }
    }
}
