using Tools.Infrastructure;

namespace Tools.Testing
{
    public class ConnectionStringForTests : IConnectionString
    {
        public string Connection => "Data Source=school_for_test.db";
    }
}
