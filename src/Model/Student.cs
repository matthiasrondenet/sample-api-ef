using System.Collections.Generic;
using System;
using System.Linq;
using Tools.Infrastructure;

namespace Model
{
    public class Student : IAggregateRoot
    {
        public           int                     Id          { get; }
        public           string                  LastName    { get; }
        public           string                  FirstName   { get; }
        public           string                  Email       { get; }
        public           string                  FullName    => $"{this.LastName} {this.FirstName}";
        public           IEnumerable<Enrollment> Enrollments => this.enrollments.AsEnumerable();
        private readonly ICollection<Enrollment> enrollments = new List<Enrollment>();

        public Student(string lastName, string firstName, string email)
        {
            this.LastName  = lastName  ?? throw new ArgumentNullException(nameof(lastName));
            this.FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            this.Email     = email     ?? throw new ArgumentNullException(nameof(email));
        }

        public void Enroll(Course course)
        {
            if (course == null) throw new ArgumentNullException(nameof(course));

            this.enrollments.Add(new Enrollment(course, this));
        }
    }
}
