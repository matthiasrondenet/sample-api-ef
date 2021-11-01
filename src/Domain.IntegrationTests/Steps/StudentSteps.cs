using Model;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Domain.IntegrationTests.Steps
{
    public class StudentContext
    {
        public Student Student { get; set; }
    }

    [Binding]
    public class StudentSteps
    {
        private readonly StudentContext studentContext;

        public StudentSteps(StudentContext studentContext)
        {
            this.studentContext = studentContext;
        }

        [Given(@"a student")]
        public void GivenAStudent(Table table)
        {
            var student = table.CreateInstance<Student>();
            this.studentContext.Student = student;
        }
    }
}
