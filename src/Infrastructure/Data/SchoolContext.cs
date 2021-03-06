using Microsoft.EntityFrameworkCore;
using Model;
using System.Reflection;

namespace Infrastructure.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(ISchoolContextOptionsFactory optionsFactory) : base(optionsFactory.Create())
        {
        }

        public DbSet<Course>     Courses     { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student>    Students    { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
