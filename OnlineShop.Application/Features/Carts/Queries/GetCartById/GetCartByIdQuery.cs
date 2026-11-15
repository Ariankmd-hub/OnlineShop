using MediatR;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Application.Features.Carts.Queries.GetCartById
{
    public record class GetCartByIdQuery
        (
        Guid CartId
        ) : IRequest<Cart>
    {

    }
}
