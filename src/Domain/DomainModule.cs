using Autofac;

namespace Domain
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EnrollmentService>().As<IEnrollmentService>();
            builder.RegisterType<NotificationService>().As<INotificationService>();
            builder.RegisterType<EmailConfig>().As<IEmailConfig>().SingleInstance();
        }
    }
}
