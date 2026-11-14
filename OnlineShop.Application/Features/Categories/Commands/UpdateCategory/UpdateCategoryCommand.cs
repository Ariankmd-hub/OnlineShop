using MediatR;

namespace OnlineShop.Application.Features.Categories.Commands.UpdateCategory
{
    public record class UpdateCategoryCommand
        (
        Guid Id,
        string Name ,
        string Description 
        ) : IRequest<Guid> 
    {
    }
}
