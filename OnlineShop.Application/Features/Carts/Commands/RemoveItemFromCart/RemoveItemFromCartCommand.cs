using MediatR;

namespace OnlineShop.Application.Features.Carts.Commands.RemoveItemFromCart
{
    public record class RemoveItemFromCartCommand
        (
        Guid Id
        ) : IRequest<bool>
    {
    }
}
