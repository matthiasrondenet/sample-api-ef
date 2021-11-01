using Autofac;
using Infrastructure.Data;
using Infrastructure.Email;
using Tools.Infrastructure;

namespace Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ConnectionString>()
                   .As<IConnectionString>()
                   .SingleInstance();

            builder.RegisterType<SchoolContextOptionsFactory>()
                   .As<ISchoolContextOptionsFactory>();
            builder
               .RegisterType<SchoolContext>()
               .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(SchoolRepository<>))
                   .As(typeof(IReadRepository<>))
                   .As(typeof(IWriteRepository<>))
                   .As(typeof(IRepository<>))
                   .InstancePerLifetimeScope();

            builder.RegisterType<EmailSender>()
                   .As<IEmailSender>();
        }
    }
}
