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
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
           return await _dbSet.FindAsync(id);
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
