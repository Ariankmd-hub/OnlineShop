using OnlineShop.Domain.Common;

namespace OnlineShop.Domain.Entities
{
    public class CartItem : BaseEntity
    {
        public int Quantity { get; set; }

        // Relation(Product)
        public Guid ProductId { get; set; }
        
        // Navigation Property
        public Product? Product { get; set; } 

        // Relation Cart

        public Guid CartId { get; set; }

        // Navigation Property 
        public Cart? Cart { get; set; }
    }
}
