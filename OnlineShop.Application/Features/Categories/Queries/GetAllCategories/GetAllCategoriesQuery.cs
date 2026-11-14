using MediatR;
namespace OnlineShop.Application.Features.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesQuery : IRequest<IEnumerable<GetAllCategoriesResponse>> 
    {
    }
}
