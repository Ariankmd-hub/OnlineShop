using OnlineShop.Domain.Common;

namespace OnlineShop.Domain.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default); 
    }
}
