using System.Collections.Generic;using System.Threading.Tasks;using Api.Controllers;using Api.Dtos;using Domain;using FluentAssertions;using Microsoft.AspNetCore.Mvc;using Model;using Model.Testing;using NSubstitute;using Tools.Infrastructure;using Xunit;namespace Api.Tests{public class StudentControllerTests{private readonly StudentController studentController;private readonly IRepository<Student> studentRepository;private readonly IRepository<Course> courseRepository;private readonly IEnrollmentService enrollmentService;public StudentControllerTests(){this.studentRepository = Substitute.For<IRepository<Student>>();this.courseRepository = Substitute.For<IRepository<Course>>();this.enrollmentService = Substitute.For<IEnrollmentService>();this.studentController = new StudentController(this.studentRepository, this.courseRepository, this.enrollmentService);}[Fact]public async Task Get_Should_return_student_response(){ 
// Act
const int studentId = -1;var student = SchoolFaker.Student.Generate();var expectedStudentResponse = new StudentResponse{LastName = student.LastName,FirstName = student.FirstName,Enrollments = new List<StudentEnrollmentResponse>()};this.studentRepository.Find(studentId).Returns(student);var expected = new OkObjectResult(expectedStudentResponse); 
// Arrange
var response =await this.studentController.Get(studentId); 
// Assert
response.Should().BeEquivalentTo(expected);await this.studentRepository.Received().Find(studentId);}[Fact]public async Task Get_Should_return_not_found_When_unknown_student_id(){ 
// Act
const int studentId = -1;var expected = new NotFoundObjectResult(studentId); 
// Arrange
var response = await this.studentController.Get(studentId); 
// Assert
response.Should().BeEquivalentTo(expected);await this.studentRepository.Received().Find(studentId);}}}