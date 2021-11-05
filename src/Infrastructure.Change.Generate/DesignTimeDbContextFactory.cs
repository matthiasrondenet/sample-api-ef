using System.IO;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Change.Generate
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SchoolContext>
    {
        public SchoolContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                          .AddJsonFile("appsettings.Development.json", false)
                                                          .Build();
            var connectionString = new ConnectionString(configuration);
            var optionsFactory   = new SchoolContextOptionsFactory(connectionString);
            return new SchoolContext(optionsFactory);
        }
    }
}
