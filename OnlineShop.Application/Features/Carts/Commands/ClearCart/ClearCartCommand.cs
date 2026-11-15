using MediatR;

namespace OnlineShop.Application.Features.Carts.Commands.ClearCart
{
    public record class ClearCartCommand
        (
        Guid CartId
        ) : IRequest<bool>
    {
    }
}
