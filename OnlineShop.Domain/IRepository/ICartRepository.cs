using OnlineShop.Domain.Entities;

namespace OnlineShop.Domain.IRepository
{
    public interface ICartRepository : IGenericRepository<Cart>
    {
        Task<Cart?> GetCartWithItemsAsync(Guid cartId, CancellationToken cancellationToken = default);
    }
}
