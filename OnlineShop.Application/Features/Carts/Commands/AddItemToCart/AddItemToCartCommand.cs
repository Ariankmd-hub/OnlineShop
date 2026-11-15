using MediatR;

namespace OnlineShop.Application.Features.Carts.Commands.AddItemToCart
{
    public record class AddItemToCartCommand
        (
        int Quantity,
        Guid ProductId,
        Guid? CartId

        ) : IRequest<Guid>
    {
    }
}
