using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.IRepository;
using OnlineShop.Infrastructure.Persistence;

namespace OnlineShop.Infrastructure.Repository
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository  
    {
        private readonly AppDbContext _context;
        public CartRepository(AppDbContext appDbContext) : base(appDbContext) 
        {
            _context = appDbContext;
        }
        public async Task<Cart?> GetCartWithItemsAsync
            (Guid cartId, CancellationToken cancellationToken = default)
        {
            return await _context.Carts
                .Include(c => c.CartItems)
                .FirstOrDefaultAsync(c => c.Id == cartId, cancellationToken);
        }


    }
}
