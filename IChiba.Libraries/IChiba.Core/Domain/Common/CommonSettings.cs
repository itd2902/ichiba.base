using IChiba.Core.Configuration;

namespace IChiba.Core.Domain
{
    /// <summary>
    /// Common settings
    /// </summary>
    public class CommonSettings : ISettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether to compress response (gzip by default). 
        /// You may want to disable it, for example, If you have an active IIS Dynamic Compression Module configured at the server level
        /// </summary>
        public bool UseResponseCompression { get; set; }
    }

    public class GetDataSettings : ISettings
    {
        public int TopSize { get; set; } = 10;

        public int MaxTopSize { get; set; } = 50;
    }
}
