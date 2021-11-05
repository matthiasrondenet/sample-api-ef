using System;

namespace Model
{
    public enum Grade
    {
        A,
        B,
        C,
        D,
        F
    }

    public class Enrollment
    {
        public int     Id      { get; }
        public Grade?  Grade   { get; set; }
        public Course  Course  { get; set; }
        public Student Student { get; set; }

        public Enrollment()
        {
        }

        public Enrollment(Course course, Student student)
        {
            this.Course  = course  ?? throw new ArgumentNullException(nameof(course));
            this.Student = student ?? throw new ArgumentNullException(nameof(student));
        }
    }
}
