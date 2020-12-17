using System.Collections.Generic;

namespace IChiba.Web.Framework.Models
{
    /// <summary>
    /// Represents localized model
    /// </summary>
    public interface ILocalizedModel
    {
    }

    /// <summary>
    /// Represents generic localized model
    /// </summary>
    /// <typeparam name="T">Localized model type</typeparam>
    public interface ILocalizedModel<T> : ILocalizedModel where T : ILocalizedLocaleModel
    {
        public IList<T> Locales { get; set; }

        // Key: Field Name; Value: Label Value
        public IDictionary<string, string> LocaleLabels { get; set; }
    }

    /// <summary>
    /// Represents localized locale model
    /// </summary>
    public interface ILocalizedLocaleModel
    {
        /// <summary>
        /// Gets or sets the language identifier
        /// </summary>
        string LanguageId { get; set; }

        /// <summary>
        /// ISO two-letter language code
        /// </summary>
        string _LanguageCode { get; set; }

        /// <summary>
        /// ISO two-letter country code
        /// </summary>
        string _FlagCode { get; set; }
    }
}
