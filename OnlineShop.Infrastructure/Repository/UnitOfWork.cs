
using OnlineShop.Domain.Common;
using OnlineShop.Domain.IRepository;
using OnlineShop.Infrastructure.Persistence;

namespace OnlineShop.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public void Dispose()
        {
            _context.Dispose();
        }
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
