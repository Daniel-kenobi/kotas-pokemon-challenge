using Domain.Model;

namespace Domain.Interfaces.Repository
{
    public interface IRepositoryBase<T> where T : EntityBase
    {
        Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default);
        Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
        Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<T> GetOneAsync(T entity, CancellationToken cancellationToken = default);
    }
}
