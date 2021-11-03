using System;using System.Threading.Tasks;using FluentAssertions;using Model;using Model.Testing;using NSubstitute;using Tools.Infrastructure;using Xunit;namespace Domain.Tests{public class EnrollmentServiceTests{private readonly EnrollmentService enrollmentService;private readonly IRepository<Student> studentRepository;private readonly INotificationService notificationService;public EnrollmentServiceTests(){this.studentRepository = Substitute.For<IRepository<Student>>();this.notificationService = Substitute.For<INotificationService>();this.enrollmentService = new EnrollmentService(this.studentRepository, this.notificationService);}[Fact]public async Task Should_Update_and_call_notification(){ 
// Arrange
var student = SchoolFaker.Student.Generate();var course = SchoolFaker.Course.Generate();var date = new DateTime(2020, 01, 01); 
// Act
await this.enrollmentService.Enroll(student, course, date); 
// Assert
await this.studentRepository.Received().Update(student);this.notificationService.Received().StudentEnrolled(student, course);}[Fact]public async Task Should_throw_exception_When_date_after_course_start_date(){ 
// Arrange
var student = SchoolFaker.Student.Generate();var course = SchoolFaker.Course.FinishWith((_,c)=>c.StartDate = new DateTime(2019,12,01)).Generate();var date = new DateTime(2020, 01, 01); 
// Act
Func<Task> action = async ()=> await this.enrollmentService.Enroll(student, course, date); 
// Assert
await action.Should().ThrowAsync<CourseAlreadyStartedNoEnrollmentException>().WithMessage($"Course has already started on 2019-12-01. Enrollment impossible.");await this.studentRepository.DidNotReceive().Update(Arg.Any<Student>());this.notificationService.DidNotReceive().StudentEnrolled(Arg.Any<Student>(), Arg.Any<Course>());}}}