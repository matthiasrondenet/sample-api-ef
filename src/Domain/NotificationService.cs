namespace Domain
{
    using Infrastructure.Email;
    using Model;

    public interface INotificationService
    {
        void StudentEnrolled(Student student, Course course);
    }

    public class NotificationService : INotificationService
    {
        private readonly IEmailSender emailSender;
        private readonly IEmailConfig emailConfig;

        public NotificationService(IEmailSender emailSender, IEmailConfig emailConfig)
        {
            this.emailSender = emailSender;
            this.emailConfig = emailConfig;
        }

        public void StudentEnrolled(Student student, Course course)
        {
            const string? subject = "Confirmation - Enrollment";
            var           body    = $"Hello {student.FirstName}!" + $"You just enrolled to the course {course.Title}.";
            this.emailSender.Send(student.Email, this.emailConfig.From, subject, body);
        }
    }
}
