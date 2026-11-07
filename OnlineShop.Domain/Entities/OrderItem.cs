using OnlineShop.Domain.Common;

namespace OnlineShop.Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        public int Quantity { get; set; }

        // At the moment price
        public decimal UnitPrice { get; set; }

        public Guid OrderId { get; set; }

        public Order? Order { get; set; }

        public Guid ProductId { get; set; }

        public Product? Product { get; set; }

     

            
    }
}
