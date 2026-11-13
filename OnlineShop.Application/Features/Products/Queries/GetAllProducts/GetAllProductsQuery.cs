using MediatR;
// this is request to our handler
// GetAllResponse is our Exit.
namespace OnlineShop.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<IEnumerable<GetAllProductsResponse>>
    {
    }
}
