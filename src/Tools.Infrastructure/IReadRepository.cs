using System.Threading.Tasks;

namespace Tools.Infrastructure
{
    public interface IReadRepository<T> where T : class, IAggregateRoot
    {
        Task<T?> Find<TId>(TId id) where TId : notnull;
    }
}
