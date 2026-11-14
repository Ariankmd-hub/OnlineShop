namespace OnlineShop.Application.Features.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesResponse
    {
        public Guid Id { get; set; }

        public DateTime CreatedAtUtc { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
