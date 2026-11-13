using MediatR;

namespace OnlineShop.Application.Features.Products.Commands.UpdateProduct
{
    public record class UpdateProductCommand
        (
        Guid Id,
        string Name,
        decimal Price,
        string Description,
        int Stock,
        string ImageUrl,
        Guid CategoryId
        ) : IRequest<Guid>;
}