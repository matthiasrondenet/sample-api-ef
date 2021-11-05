using Model;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Domain.IntegrationTests.Steps
{
    public class CourseContext
    {
        public Course Course { get; set; }
    }

    [Binding]
    public class CourseSteps
    {
        private readonly CourseContext courseContext;

        public CourseSteps(CourseContext courseContext)
        {
            this.courseContext = courseContext;
        }

        [Given(@"a course")]
        public void GivenACourse(Table table)
        {
            var course = table.CreateInstance<Course>();
            this.courseContext.Course = course;
        }
    }
}
