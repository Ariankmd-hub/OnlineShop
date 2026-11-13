
using MediatR;


namespace OnlineShop.Application.Features.Products.Queries.GetProductById
{
    public record class GetProductByIdQuery(Guid Id) : IRequest<GetProductByIdResponse?>
    {
    }
}
