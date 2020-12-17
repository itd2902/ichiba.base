using IChiba.Caching;
using IChiba.Core.Domain.Master;
using IChiba.Core.Infrastructure;
using IChiba.Services.Caching;

namespace IChiba.Services.Configuration.Caching
{
    /// <summary>
    /// Represents a setting cache event consumer
    /// </summary>
    public partial class SettingCacheEventConsumer : CacheEventConsumer<Setting>
    {
        public SettingCacheEventConsumer()
            : base(EngineContext.Current.Resolve<IIChibaCacheManager>())
        {

        }
    }
}
