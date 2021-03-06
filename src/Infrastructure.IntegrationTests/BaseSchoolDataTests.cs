using Autofac;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Tools.Testing;

namespace Infrastructure.IntegrationTests
{
    public abstract class BaseSchoolDataTests : BaseDataTests
    {
        private readonly IDbContextTransaction transaction;

        protected BaseSchoolDataTests(DataHooks? dataHooks, bool applyMigration = true) : base(dataHooks ?? new DataHooks())
        {
            var context = this.Hooks.Container.Resolve<SchoolContext>();
            if (applyMigration)
            {
                context.Database.Migrate();
            }
            else
            {
                context.Database.EnsureCreated();
                var dbCreator = (RelationalDatabaseCreator)context.Database.GetService<IDatabaseCreator>();
                if (!dbCreator.HasTables()) dbCreator.CreateTables();
            }

            this.transaction = context.Database.BeginTransaction();
        }

        public override void Dispose()
        {
            this.transaction?.Rollback();
            this.transaction?.Dispose();
            base.Dispose();
        }
    }
}
