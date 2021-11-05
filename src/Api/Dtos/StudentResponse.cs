using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Model;

namespace Api.Dtos
{
    public class CreateStudentRequest
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }
    }

    public class StudentResponse
    {
        public int                                    Id          { get; set; }
        public string                                 FirstName   { get; set; }
        public string                                 LastName    { get; set; }
        public IEnumerable<StudentEnrollmentResponse> Enrollments { get; set; }

        public static StudentResponse New(Student student)
        {
            return new StudentResponse
                   {
                       Id          = student.Id, FirstName = student.FirstName, LastName = student.LastName,
                       Enrollments = student.Enrollments.Select(StudentEnrollmentResponse.New)
                   };
        }
    }

    public class StudentEnrollmentResponse
    {
        public string CourseTitle { get; set; }

        public static StudentEnrollmentResponse New(Enrollment enrollment)
        {
            return new StudentEnrollmentResponse { CourseTitle = enrollment.Course.Title };
        }
    }
}
