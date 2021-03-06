using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Api.Dtos;
using Domain;
using Model;
using Tools.Infrastructure;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IRepository<Student> studentRepository;
        private readonly IRepository<Course>  courseRepository;
        private readonly IEnrollmentService   enrollmentService;

        public StudentController(IRepository<Student> studentRepository, IRepository<Course> courseRepository, IEnrollmentService enrollmentService)
        {
            this.studentRepository = studentRepository;
            this.courseRepository  = courseRepository;
            this.enrollmentService = enrollmentService;
        }

        [HttpGet("{studentId:int}")]
        public async Task<IActionResult> Get(int studentId)
        {
            var student = await this.studentRepository.Find(studentId);
            if (student == null) return this.NotFound(studentId);

            return this.Ok(StudentResponse.New(student));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateStudentRequest createStudentRequest)
        {
            var student = new Student(createStudentRequest.LastName, createStudentRequest.FirstName, createStudentRequest.Email);
            await this.studentRepository.Add(student);
            return this.Ok(StudentResponse.New(student));
        }

        [HttpPut("enroll/{studentId:int}")]
        public async Task<IActionResult> Enroll(int studentId, int courseId)
        {
            var student = await this.studentRepository.Find(studentId);
            if (student == null) return this.NotFound(studentId);

            var course = await this.courseRepository.Find(courseId);
            if (course == null) return this.NotFound(courseId);

            await this.enrollmentService.Enroll(student, course, DateTime.Today);
            return this.Ok();
        }
    }
}
