using MediatR;

namespace OnlineShop.Application.Features.Products.Commands.DeleteProduct
{
    public record class DeleteProductCommand
        (
        Guid Id

        ) : IRequest<bool>;
}
