using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.IRepository;
using OnlineShop.Infrastructure.Persistence;

namespace OnlineShop.Infrastructure.Repository
{
    public class CartItemRepository : GenericRepository<CartItem> , ICartItemRepository
    {
        private readonly AppDbContext _Context;
        public CartItemRepository(AppDbContext Context) : base(Context) 
        {
            _Context = Context;
        }

        public async Task<CartItem?> GetByCartAndProductAsync
            (Guid cartId, Guid productId, CancellationToken cancellationToken)
        {
           return await _Context.CartItems.FirstOrDefaultAsync
                (x => x.ProductId == productId && x.CartId == cartId, cancellationToken);
        }
        public async Task<IEnumerable<CartItem>> GetByCartIdAsync
            (Guid cartId, CancellationToken cancellationToken)
        {
            return await _Context.CartItems.Where
                (x => x.CartId == cartId).ToListAsync (cancellationToken);
        }
    }
}