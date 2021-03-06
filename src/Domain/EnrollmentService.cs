using System;
using System.Threading.Tasks;
using Model;
using Tools.Infrastructure;

namespace Domain
{
    public interface IEnrollmentService
    {
        Task Enroll(Student student, Course course, DateTime date);
    }

    public class EnrollmentService : IEnrollmentService
    {
        private readonly IRepository<Student> studentRepository;
        private readonly INotificationService notificationService;

        public EnrollmentService(IRepository<Student> studentRepository, INotificationService notificationService)
        {
            this.studentRepository   = studentRepository;
            this.notificationService = notificationService;
        }

        public async Task Enroll(Student student, Course course, DateTime date)
        {
            if (course.StartDate < date) throw new CourseAlreadyStartedNoEnrollmentException(course.StartDate);

            student.Enroll(course);
            await this.studentRepository.Update(student);
            this.notificationService.StudentEnrolled(student, course);
        }
    }
}
