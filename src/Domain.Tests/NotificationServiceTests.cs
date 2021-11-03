using Infrastructure.Email;using Model.Testing;using NSubstitute;using Xunit;namespace Domain.Tests{public class NotificationServiceTests{private readonly NotificationService notificationService;private readonly IEmailSender emailService;private readonly IEmailConfig emailConfig;public NotificationServiceTests(){this.emailService = Substitute.For<IEmailSender>();this.emailConfig = Substitute.For<IEmailConfig>();this.notificationService = new NotificationService(this.emailService, this.emailConfig);}[Fact]public void Should_call_email_service(){ 
// Arrange
const string from = "test@univ.com";var student = SchoolFaker.Student.Generate();var course = SchoolFaker.Course.Generate();this.emailConfig.From.Returns(from); 
// Act
this.notificationService.StudentEnrolled(student, course); 
// Assert
}}}