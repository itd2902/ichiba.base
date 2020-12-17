using IChiba.Core.Configuration;

namespace IChiba.Core.Domain.Localization
{
    /// <summary>
    /// Localization settings
    /// </summary>
    public class LocalizationSettings : ISettings
    {
        /// <summary>
        /// A value indicating whether to load all LocaleStringResource records on application startup
        /// </summary>
        public bool LoadAllLocaleRecordsOnStartup { get; set; } = true;
    }
}
