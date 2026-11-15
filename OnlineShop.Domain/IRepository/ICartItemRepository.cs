using OnlineShop.Domain.Entities;

namespace OnlineShop.Domain.IRepository
{
    public interface ICartItemRepository : IGenericRepository<CartItem>
    {
        Task<CartItem?> GetByCartAndProductAsync
            (Guid cartId, Guid productId, CancellationToken cancellationToken);
        Task<IEnumerable<CartItem>> GetByCartIdAsync (Guid cartId, CancellationToken cancellationToken);
    }
}
