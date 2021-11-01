using System.Threading.Tasks;

namespace Tools.Infrastructure
{
    public interface IWriteRepository<T> where T : class, IAggregateRoot
    {
        Task<T> Add(T entity);

        Task Add(params T[] entities);

        Task Update(params T[] entities);
    }
}
