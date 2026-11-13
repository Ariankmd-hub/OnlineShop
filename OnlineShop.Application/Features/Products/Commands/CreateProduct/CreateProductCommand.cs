using MediatR;
// record class  == record  , doing all the ctor , propery and public in background.
namespace OnlineShop.Application.Features.Products.Commands.CreateProduct
{
    public record class CreateProductCommand
        (
         string Name,
         string Description,
         decimal Price,
         int Stock,
         string? ImageUrl,
         Guid CategoryId


        ) : IRequest<Guid>;
}
