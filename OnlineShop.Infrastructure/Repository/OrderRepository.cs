using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.IRepository;
using OnlineShop.Infrastructure.Persistence;

namespace OnlineShop.Infrastructure.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly AppDbContext _context;
        public OrderRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Order?> GetOrderWithItemsAsync
            (Guid orderId, CancellationToken cancellationToken = default)
        {
            return await _context.Orders.Include(o => o.OrderItems).
                FirstOrDefaultAsync(o => o.Id == orderId,cancellationToken); 
        }
    }
}
