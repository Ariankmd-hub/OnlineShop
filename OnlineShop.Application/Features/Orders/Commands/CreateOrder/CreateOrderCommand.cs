using MediatR;

namespace OnlineShop.Application.Features.Orders.Commands.CreateOrder
{
    public record class CreateOrderCommand
        (
        Guid CartId

        ) : IRequest<Guid>
    {
    }
}
