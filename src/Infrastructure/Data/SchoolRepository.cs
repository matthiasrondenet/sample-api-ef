using Tools.Infrastructure;

namespace Infrastructure.Data
{
    public class SchoolRepository<T> : EfRepository<T> where T : class, IAggregateRoot
    {
        public SchoolRepository(SchoolContext dbContext) : base(dbContext)
        {
        }
    }
}
