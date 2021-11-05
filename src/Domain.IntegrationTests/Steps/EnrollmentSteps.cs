using System;
using Autofac;
using FluentAssertions;
using Infrastructure.Email;
using NSubstitute;
using TechTalk.SpecFlow;
using Tools.Testing;

namespace Domain.IntegrationTests.Steps
{
    [Binding]
    public class EnrollmentSteps : BaseDataTests
    {
        private readonly StudentContext studentContext;
        private readonly CourseContext  courseContext;

        public EnrollmentSteps(StudentContext studentContext, CourseContext courseContext, DomainHooks domainHooks) : base(domainHooks)
        {
            this.studentContext = studentContext;
            this.courseContext  = courseContext;
        }

        [When(@"the student enroll to the course as of (.*)")]
        public void WhenTheStudentEnrollToTheCourseAsOf(DateTime date)
        {
            this.Hooks.Container.Resolve<IEnrollmentService>().Enroll(this.studentContext.Student, this.courseContext.Course, date);
        }

        [Then(@"the student should be enrolled")]
        public void ThenTheStudentShouldBeEnrolled()
        {
            this.studentContext.Student.Enrollments.Should().HaveCount(1);
        }

        [Then(@"the student should not be enrolled")]
        public void ThenTheStudentShouldNotBeEnrolled()
        {
            this.studentContext.Student.Enrollments.Should().BeEmpty();
        }

        [Then(@"an email should be sent")]
        public void ThenAnEmailShouldBeSent()
        {
            this.Hooks.Container.Resolve<IEmailSender>()
                .Received()
                .Send(this.studentContext.Student.Email, Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>());
        }

        [Then(@"no email should be sent")]
        public void ThenNoEmailShouldBeSent()
        {
            this.Hooks.Container.Resolve<IEmailSender>().DidNotReceiveWithAnyArgs().Send(null, null, null, null);
        }
    }
}
