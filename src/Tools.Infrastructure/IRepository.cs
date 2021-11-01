namespace Tools.Infrastructure
{
    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : class, IAggregateRoot
    {
    }
}
