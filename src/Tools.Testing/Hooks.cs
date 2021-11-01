using System;
using Autofac;
using Tools.Ioc;

namespace Tools.Testing
{
    public abstract class Hooks : IDisposable
    {
        public IContainer Container { get; }

        protected Hooks()
        {
            this.Container = this.BuildContainer();
        }

        private IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            AutofacSetUp.AutoRegisterModules(builder);

            this.OverrideRegister(builder);

            return builder.Build();
        }

        protected abstract void OverrideRegister(ContainerBuilder containerBuilder);

        public void Dispose()
        {
            this.Container?.Dispose();
        }
    }
}
