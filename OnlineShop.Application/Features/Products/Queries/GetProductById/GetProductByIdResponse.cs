
namespace OnlineShop.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdResponse
    {
        public Guid Id { get; set; }

        public DateTime CreatedAtUtc { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string Description { get; set; } = string.Empty;

        public int Stock { get; set; }

        public string? ImageUrl { get; set; }


        public Guid CategoryId { get; set; }
    }
}
