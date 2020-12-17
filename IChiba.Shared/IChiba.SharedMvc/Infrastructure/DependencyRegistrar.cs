using Autofac;
using IChiba.Core.Configuration;
using IChiba.Core.Infrastructure;
using IChiba.Core.Infrastructure.DependencyManagement;

namespace IChiba.SharedMvc.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, IChibaConfig config)
        {
            
        }

        public int Order => 1;
    }
}
