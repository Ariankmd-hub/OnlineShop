using OnlineShop.Domain.Common;
using OnlineShop.Domain.Enums;

namespace OnlineShop.Domain.Entities
{
    public class Order : BaseEntity
    {
        public decimal  TotalAmount { get; set; }

        public OrderStatus Status { get; set; } = OrderStatus.Pending;

       
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
