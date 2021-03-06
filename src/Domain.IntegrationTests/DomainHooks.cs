using Autofac;
using Infrastructure.Email;
using Microsoft.Extensions.Configuration;
using Model;
using NSubstitute;
using Tools.Infrastructure;
using Tools.Testing;

namespace Domain.IntegrationTests
{
    public class DomainHooks : Hooks
    {
        protected override void OverrideRegister(ContainerBuilder containerBuilder)
        {
            // todo, make generic
            containerBuilder.RegisterInstance(Substitute.For<IRepository<Student>>()).As<IRepository<Student>>();
            containerBuilder.RegisterInstance(Substitute.For<IRepository<Course>>()).As<IRepository<Course>>();
            containerBuilder.RegisterInstance(Substitute.For<IEmailSender>()).As<IEmailSender>();
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true).Build();
            containerBuilder.RegisterInstance<IConfiguration>(configuration);
        }
    }
}
