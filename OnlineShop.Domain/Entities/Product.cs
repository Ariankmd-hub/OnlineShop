using OnlineShop.Domain.Common;

namespace OnlineShop.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string Description { get; set; } = string.Empty;

        public int Stock { get; set; }

        public string? ImageUrl { get; set; } 

        // Relation =  1 to many 
        public Guid CategoryId { get; set; }
        
        // Navigation Property 
        public Category? Category { get; set; } 

    }
}
