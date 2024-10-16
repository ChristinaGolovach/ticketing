using Microsoft.EntityFrameworkCore;

namespace Ticketing.Shared.Data.Repository
{
    public class Repository<T, TContext> : IRepository<T, TContext> 
        where T : BaseEntity 
        where TContext : DbContext
    {
        private readonly TContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(TContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbSet.FindAsync(id, cancellationToken);
        }

        public async Task<IList<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbSet.ToListAsync(cancellationToken);
        }

        public IQueryable<T> Query()
        {
            return _dbSet;
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);

            //_dbSet.Attach(entity);
            //_dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            entity.Deleted = true;
            _dbSet.Update(entity);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
