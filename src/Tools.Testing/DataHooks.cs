using Autofac;
using Tools.Infrastructure;

namespace Tools.Testing
{
    public class DataHooks : Hooks
    {
        protected override void OverrideRegister(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<ConnectionStringForTests>().As<IConnectionString>();
        }
    }
}
