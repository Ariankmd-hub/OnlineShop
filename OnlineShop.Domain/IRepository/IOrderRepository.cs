using OnlineShop.Domain.Entities;

namespace OnlineShop.Domain.IRepository
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<Order?> GetOrderWithItemsAsync
            (Guid orderId, CancellationToken cancellationToken = default);
    }
}
