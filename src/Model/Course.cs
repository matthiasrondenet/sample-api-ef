using System;
using System.Collections.Generic;
using System.Linq;
using Tools.Infrastructure;

namespace Model
{
    public class Course : IAggregateRoot
    {
        public int      Id        { get; }
        public string   Title     { get; }
        public DateTime StartDate { get; }
        public int?     Capacity  { get; }

        public IEnumerable<Enrollment> Enrollments => this.enrollments.AsEnumerable();

        private readonly ICollection<Enrollment> enrollments = new List<Enrollment>();

        public Course(string title, DateTime startDate, int? capacity = null)
        {
            this.Title     = title ?? throw new ArgumentNullException(nameof(title));
            this.StartDate = startDate;
            this.Capacity  = capacity;
        }
    }
}
