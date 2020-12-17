namespace IChiba.Caching
{
    public partial class CachingHelper
    {
        public static readonly string HybridProviderParameterName = "hybridProvider";

        public static class Configs
        {
            public static readonly string CacheName = "IChiba:Caching";
            public static readonly string HybridTopicName = "IChiba:Caching:Hybrid";

            public static class ProviderNames
            {
                public static readonly string InMemory = "IChiba:Caching:InMemory";
                public static readonly string Redis = "IChiba:Caching:Redis";
                public static readonly string Hybrid = "IChiba:Caching:Hybrid";
            }

            public static class ConfigSectionNames
            {
                public static readonly string InMemory = "Caching:InMemory";
                public static readonly string Redis = "Caching:Redis";
                public static readonly string RedisBus = "Caching:RedisBus";
            }
        }

        public static class SerializerNames
        {
            public static readonly string Json = "json";
            public static readonly string MessagePack = "msgpack";
        }
    }
}
