using Microsoft.EntityFrameworkCore;

namespace Ticketing.Shared.Data.Repository
{
    public interface IRepository<T, TContext>
        where T : BaseEntity
        where TContext : DbContext
    {
        Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IList<T>> GetAllAsync(CancellationToken cancellationToken = default);
        IQueryable<T> Query();
        Task AddAsync(T entity, CancellationToken cancellationToken = default);
        void Update(T entity);
        void Delete(T entity);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
