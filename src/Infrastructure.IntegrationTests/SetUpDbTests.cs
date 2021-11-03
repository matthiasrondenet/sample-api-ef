using System.Linq;using Autofac;using FluentAssertions;using Infrastructure.Data;using Microsoft.EntityFrameworkCore;using Model.Testing;using Tools.Testing;using Xunit;namespace Infrastructure.IntegrationTests{[Trait("Category", "integration")][Trait("Category", "database")]public class SetUpDbTests : BaseSchoolDataTests{private readonly SchoolContext schoolContext;public SetUpDbTests(DataHooks? dataHooks = null) : base(dataHooks){this.schoolContext = this.Hooks.Container.Resolve<SchoolContext>();}[Fact]public void Should_add_student_course(){ 
// Arrange
var student = SchoolFaker.Student.Generate();var course = SchoolFaker.Course.Generate(); 
// Act
this.schoolContext.Students.Add(student);this.schoolContext.Courses.Add(course);this.schoolContext.SaveChanges(); 
// Assert
this.schoolContext.Students.Count().Should().Be(1);this.schoolContext.Courses.Count().Should().Be(1);}[Fact]public void Should_enroll_student(){ 
// Arrange
var student = SchoolFaker.Student.Generate();var course = SchoolFaker.Course.Generate(); 
// Act
this.schoolContext.Students.Add(student);this.schoolContext.Courses.Add(course);student.Enroll(course);this.schoolContext.SaveChanges(); 
// Assert
 
// this.schoolContext.Students.Count().Should().Be(1);
 
// this.schoolContext.Courses.Count().Should().Be(1);
 
// this.schoolContext.Enrollments.Count().Should().Be(1);
this.schoolContext.Courses.Include(x => x.Enrollments).Single().Enrollments.Should().HaveCount(1);this.schoolContext.Students.Single().Enrollments.Should().HaveCount(1);}}}