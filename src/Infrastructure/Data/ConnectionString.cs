using Microsoft.Extensions.Configuration;
using Tools.Infrastructure;

namespace Infrastructure.Data
{
    public class ConnectionString : IConnectionString
    {
        private readonly IConfiguration configuration;

        public ConnectionString(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string Connection => this.configuration.GetConnectionString("school");
    }
}
