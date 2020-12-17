using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Core;
using EasyCaching.Core;
using IChiba.Caching;
using IChiba.Core.Domain.Master;
using IChiba.Core.Domain.OP;
using IChiba.Core.Infrastructure;
using IChiba.Data;
using LinqToDB.Data;

namespace IChiba.Web.Framework.Infrastructure.Extensions
{
    public static class ContainerBuilderExtensions
    {
        public static void RegisterDataConnection(this ContainerBuilder builder, IEnumerable<string> connectionStringNames)
        {
            if (connectionStringNames.Contains(DataConnectionHelper.ConnectionStringNames.Master))
            {
                builder.RegisterType<MasterDataConnection>()
                    .Named<DataConnection>(DataConnectionHelper.ConnectionStringNames.Master)
                    .InstancePerDependency();
            }
            if (connectionStringNames.Contains(DataConnectionHelper.ConnectionStringNames.OP))
            {
                builder.RegisterType<OPDataConnection>()
                    .Named<DataConnection>(DataConnectionHelper.ConnectionStringNames.OP)
                    .InstancePerDependency();
            }

            builder.Register<Func<string, DataConnection>>(c =>
            {
                var cc = c.Resolve<IComponentContext>();
                return connectionStringName => cc.ResolveNamed<DataConnection>(connectionStringName);
            });

            builder.Register<Func<string, Lazy<DataConnection>>>(c =>
            {
                var cc = c.Resolve<IComponentContext>();
                return connectionStringName => cc.ResolveNamed<Lazy<DataConnection>>(connectionStringName);
            });
        }

        public static void RegisterRepository(this ContainerBuilder builder, IEnumerable<string> connectionStringNames)
        {
            if (connectionStringNames.Contains(DataConnectionHelper.ConnectionStringNames.Master))
            {
                builder.RegisterGeneric(typeof(EntityRepository<>))
                    .Named(DataConnectionHelper.ConnectionStringNames.Master, typeof(IRepository<>))
                    .WithParameter(new ResolvedParameter(
                        (pi, ctx) => pi.ParameterType == typeof(DataConnection) && pi.Name == DataConnectionHelper.ParameterName,
                        (pi, ctx) => EngineContext.Current.Resolve<DataConnection>(DataConnectionHelper.ConnectionStringNames.Master)))
                    .InstancePerLifetimeScope();
            }
            if (connectionStringNames.Contains(DataConnectionHelper.ConnectionStringNames.OP))
            {
                builder.RegisterGeneric(typeof(EntityRepository<>))
                    .Named(DataConnectionHelper.ConnectionStringNames.OP, typeof(IRepository<>))
                    .WithParameter(new ResolvedParameter(
                        (pi, ctx) => pi.ParameterType == typeof(DataConnection) && pi.Name == DataConnectionHelper.ParameterName,
                        (pi, ctx) => EngineContext.Current.Resolve<DataConnection>(DataConnectionHelper.ConnectionStringNames.OP)))
                    .InstancePerLifetimeScope();
            }
        }

        public static void RegisterCacheManager(this ContainerBuilder builder)
        {
            builder.RegisterType<IChibaCacheManager>()
                .As<IIChibaCacheManager>()
                .WithParameter(new ResolvedParameter(
                    (pi, ctx) => pi.ParameterType == typeof(IHybridCachingProvider) && pi.Name == CachingHelper.HybridProviderParameterName,
                    (pi, ctx) => EngineContext.Current.Resolve<IHybridProviderFactory>().GetHybridCachingProvider(CachingHelper.Configs.ProviderNames.Hybrid)))
                .SingleInstance();
        }
    }
}
