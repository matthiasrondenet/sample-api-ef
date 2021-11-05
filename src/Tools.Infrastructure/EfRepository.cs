using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Tools.Infrastructure
{
    public interface IRepository<T> where T : class, IAggregateRoot
    {
        Task<T?> Find<TId>(TId     id) where TId : notnull;
        Task<T>  Add(T             entity);
        Task     Add(params    T[] entities);
        Task     Update(params T[] entities);
    }

    public abstract class EfRepository<T> : IRepository<T> where T : class, IAggregateRoot
    {
        private readonly DbContext dbContext;

        protected EfRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<T?> Find<TId>(TId id) where TId : notnull
        {
            var entity = await this.dbContext.Set<T>().FindAsync(id);
            return entity;
        }

        public async Task<T> Add(T entity)
        {
            this.dbContext.Set<T>().Add(entity);
            await this.dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Add(params T[] entities)
        {
            this.dbContext.Set<T>().AddRange(entities);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task Update(params T[] entities)
        {
            this.dbContext.Set<T>().UpdateRange(entities);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
