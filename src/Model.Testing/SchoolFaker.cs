using Bogus;

namespace Model.Testing
{
    public static class SchoolFaker
    {
        public static readonly Faker<Student> Student = new Faker<Student>()
           .CustomInstantiator(f => new Student(f.Person.LastName, f.Person.FirstName, f.Person.Email));

        public static readonly Faker<Course> Course = new Faker<Course>()
           .CustomInstantiator(f => new Course(f.Random.Words(), f.Date.Future()));
    }
}
