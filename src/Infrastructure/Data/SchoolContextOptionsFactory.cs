using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tools.Infrastructure;

namespace Infrastructure.Data
{
    public interface ISchoolContextOptionsFactory
    {
        DbContextOptions<SchoolContext> Create();
    }

    public class SchoolContextOptionsFactory : ISchoolContextOptionsFactory
    {
        private readonly IConnectionString connectionString;

        public SchoolContextOptionsFactory(IConnectionString connectionString)
        {
            this.connectionString = connectionString;
        }

        public DbContextOptions<SchoolContext> Create()
        {
            var builder = new DbContextOptionsBuilder<SchoolContext>();

            // var sqlLiteBuilder = new SqliteConnectionStringBuilder(this.connectionString.Connection);
            builder.UseSqlite(
                this.connectionString.Connection,
                b =>
                    b.MigrationsAssembly("Sample.Infrastructure.Change.Generate"));

            builder.LogTo(Console.WriteLine);

            return builder.Options;
        }
    }
}
