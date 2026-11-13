using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Common;
using OnlineShop.Domain.IRepository;
using OnlineShop.Infrastructure.Persistence;

namespace OnlineShop.Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet; 
        public GenericRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
            _dbSet = _context.Set<T>();
        }
        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddAsync(entity,cancellationToken);
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbSet.ToListAsync(cancellationToken);
        }

        public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
           return await _dbSet.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
            
        }

        public void Update(T entity)
        {
           _dbSet.Update(entity);
        }
    }
}
