using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using FluentValidation.AspNetCore;
using IChiba.Caching;
using IChiba.Core;
using IChiba.Core.Configuration;
using IChiba.Core.Domain.Master;
using IChiba.Core.Domain.OP;
using IChiba.Core.Infrastructure;
using IChiba.Core.Security;
using IChiba.Data;
using IChiba.Web.Framework.Mvc.ModelBinding;
using LinqToDB.AspNet;
using LinqToDB.AspNet.Logging;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace IChiba.Web.Framework.Infrastructure.Extensions
{
    /// <summary>
    /// Represents extensions of IServiceCollection
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add services to the application and configure service provider
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        /// <param name="configuration">Configuration of the application</param>
        /// <param name="webHostEnvironment">Hosting environment</param>
        /// <returns>Configured service provider</returns>
        public static (IEngine, IChibaConfig) ConfigureApplicationServices(this IServiceCollection services,
            IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            //most of API providers require TLS 1.2 nowadays
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            //add NopConfig configuration parameters
            services.Configure<IChibaConfig>(configuration.GetSection(IChibaConfig.IChiba));

            //add hosting configuration parameters
            services.Configure<HostingConfig>(configuration.GetSection(HostingConfig.Hosting));

            services.Configure<SSOConfig>(configuration.GetSection(SSOConfig.SSO));

            var config = configuration.GetSection(IChibaConfig.IChiba).Get<IChibaConfig>();

            //add accessor to HttpContext
            services.AddHttpContextAccessor();

            //create default file provider
            CommonHelper.DefaultFileProvider = new IChibaFileProvider(webHostEnvironment);

            //initialize plugins
            var mvcCoreBuilder = services.AddMvcCore();

            //create engine and configure service provider
            var engine = EngineContext.Create();

            engine.ConfigureServices(services, configuration, config);

            return (engine, config);
        }

        /// <summary>
        /// Create, bind and register as service the specified configuration parameters 
        /// </summary>
        /// <typeparam name="TConfig">Configuration parameters</typeparam>
        /// <param name="services">Collection of service descriptors</param>
        /// <param name="configuration">Set of key/value application configuration properties</param>
        /// <returns>Instance of configuration parameters</returns>
        public static TConfig ConfigureStartupConfig<TConfig>(this IServiceCollection services, IConfiguration configuration) where TConfig : class, new()
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            //create instance of config
            var config = new TConfig();

            //bind it to the appropriate section of configuration
            configuration.Bind(config);

            //and register it as a service
            services.AddSingleton(config);

            return config;
        }

        /// <summary>
        /// Register HttpContextAccessor
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        public static void AddHttpContextAccessor(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        /// <summary>
        /// Adds data protection services
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        public static void AddIChibaDataProtection(this IServiceCollection services, IConfiguration configuration)
        {
            //check whether to persist data protection in Redis
            var config = configuration.GetSection(IChibaConfig.IChiba).Get<IChibaConfig>();
            // TODO-IChiba-DataProtection
            //services.AddDataProtection().PersistKeysToStackExchangeRedis(() =>
            //{
            //    var redisConnectionWrapper = EngineContext.Current.Resolve<IRedisConnectionWrapper>();
            //    return redisConnectionWrapper.GetDatabase(config.RedisDatabaseId ?? (int)RedisDatabaseNumber.DataProtectionKeys);
            //}, IChibaDataProtectionDefaults.RedisDataProtectionKey);
        }

        /// <summary>
        /// Add and configure MVC for the application
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        /// <returns>A builder for configuring MVC services</returns>
        public static IMvcBuilder AddIChibaMvc(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(x => x.AddPolicy("AllowAll", p => p
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()));

            services.AddHttpClient();

            //add basic MVC feature
            var mvcBuilder = services
                .AddControllersWithViews()
                .ConfigureApiBehaviorOptions(options =>
                {
                    //options.SuppressConsumesConstraintForFormFileParameters = true;
                    //options.SuppressInferBindingSourcesForParameters = true;
                    options.SuppressModelStateInvalidFilter = true;
                    //options.SuppressMapClientErrors = true;
                    //options.ClientErrorMapping[StatusCodes.Status404NotFound].Link =
                    //    "https://httpstatuses.com/404";
                });

            var config = configuration.GetSection(IChibaConfig.IChiba).Get<IChibaConfig>();

            //MVC now serializes JSON with camel case names by default, use this code to avoid it
            mvcBuilder.AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            // TODO-IChiba: Fix ModelMetadataDetailsProviders, ModelBinderProviders
            //add custom display metadata provider
            //mvcBuilder.AddMvcOptions(options => options.ModelMetadataDetailsProviders.Add(new IChibaMetadataProvider()));

            //add custom model binder provider (to the top of the provider list)
            //mvcBuilder.AddMvcOptions(options => options.ModelBinderProviders.Insert(0, new IChibaModelBinderProvider()));

            //add fluent validation
            mvcBuilder.AddFluentValidation(configuration =>
            {
                //register all available validators from Nop assemblies
                var assemblies = mvcBuilder.PartManager.ApplicationParts
                    .OfType<AssemblyPart>()
                    .Where(part => part.Name.StartsWith("IChiba", StringComparison.InvariantCultureIgnoreCase))
                    .Select(part => part.Assembly);
                configuration.RegisterValidatorsFromAssemblies(assemblies);

                //implicit/automatic validation of child properties
                configuration.ImplicitlyValidateChildProperties = true;
            });

            //register controllers as services, it'll allow to override them
            mvcBuilder.AddControllersAsServices();

            return mvcBuilder;
        }

        public static void AddIChibaDbContext(this IServiceCollection services, IConfiguration configuration, IEnumerable<string> connectionStringNames)
        {
            if (connectionStringNames.Contains(DataConnectionHelper.ConnectionStringNames.Master))
            {
                services.AddLinqToDbContext<MasterDataConnection>((provider, options) =>
                {
                    options
                        .UseSqlServer(configuration.GetConnectionString(DataConnectionHelper.ConnectionStringNames.Master))
                        .UseDefaultLogging(provider);
                });
            }
            if (connectionStringNames.Contains(DataConnectionHelper.ConnectionStringNames.OP))
            {
                services.AddLinqToDbContext<OPDataConnection>((provider, options) =>
                {
                    options
                        .UseSqlServer(configuration.GetConnectionString(DataConnectionHelper.ConnectionStringNames.OP))
                        .UseDefaultLogging(provider);
                });
            }
        }

        public static void AddIChibaCaching(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEasyCaching(options =>
            {
                // local
                options.UseInMemory(configuration,
                    CachingHelper.Configs.ProviderNames.InMemory,
                    CachingHelper.Configs.ConfigSectionNames.InMemory);
                // distributed
                options.UseRedis(configuration,
                    CachingHelper.Configs.ProviderNames.Redis,
                    CachingHelper.Configs.ConfigSectionNames.Redis);

                // combine local and distributed
                options.UseHybrid(config =>
                {
                    config.TopicName = CachingHelper.Configs.HybridTopicName;
#if DEBUG
                    config.EnableLogging = true;
#endif
                    config.LocalCacheProviderName = CachingHelper.Configs.ProviderNames.InMemory;
                    config.DistributedCacheProviderName = CachingHelper.Configs.ProviderNames.Redis;
                }, CachingHelper.Configs.ProviderNames.Hybrid)
                // use redis bus
                .WithRedisBus(configuration, CachingHelper.Configs.ConfigSectionNames.RedisBus);

                Action<JsonSerializerSettings> serializerSettings = x =>
                {
                    x.MissingMemberHandling = MissingMemberHandling.Ignore;
                    x.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    x.DateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind;
                    x.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                    x.MaxDepth = 32;
                };
                options.WithJson(serializerSettings, CachingHelper.SerializerNames.Json);
            });
        }
    }
}
