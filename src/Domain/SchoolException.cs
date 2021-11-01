using System;

namespace Domain
{
    public abstract class SchoolException : Exception
    {
        protected SchoolException(string message) : base(message)
        {
        }
    }

    public class CourseAlreadyStartedNoEnrollmentException : SchoolException
    {
        public CourseAlreadyStartedNoEnrollmentException(DateTime courseStartDate) : base(
            $"Course has already started {courseStartDate:yyyy-MM-dd}. Enrollment impossible.")
        {
        }
    }
}
