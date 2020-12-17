namespace IChiba.Caching
{
    /// <summary>
    /// Represents default values related to caching
    /// </summary>
    public static partial class CachingDefaults
    {
        /// <summary>
        /// Gets the default cache time in minutes
        /// </summary>
        public static int CacheTime => 60;

        /// <summary>
        /// Gets or sets the short term cache time in minutes
        /// </summary>
        public static int ShortTermCacheTime => 5;

        public static int DayCacheTime => 1440;

        public static int MonthCacheTime => 43200;

        /// <summary>
        /// Gets a key for caching
        /// </summary>
        /// <remarks>
        /// {0} : Entity type name
        /// {1} : Entity id
        /// </remarks>
        public static string EntityCacheKey => "ichiba.{0}.id-{1}";
    }
}
