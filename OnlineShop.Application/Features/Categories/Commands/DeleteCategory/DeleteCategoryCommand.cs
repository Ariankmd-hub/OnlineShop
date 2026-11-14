using MediatR;

namespace OnlineShop.Application.Features.Categories.Commands.DeleteCategory
{
    public record class DeleteCategoryCommand
        (
        Guid Id
        ) : IRequest<bool>
    {
    }
}
