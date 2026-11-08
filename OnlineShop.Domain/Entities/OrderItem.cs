using OnlineShop.Domain.Common;

namespace OnlineShop.Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        public int Quantity { get; set; }

        // At the moment price
        public decimal UnitPrice { get; set; }

        // Relation 
        public Guid OrderId { get; set; }

        //Navigation property 
        public Order? Order { get; set; }
       
        // Realation 
        public Guid ProductId { get; set; }

        //Navigation property
        public Product? Product { get; set; }

     

            
    }
}
