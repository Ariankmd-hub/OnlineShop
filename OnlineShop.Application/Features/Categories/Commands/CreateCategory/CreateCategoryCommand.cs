
using MediatR;
// NO NEED TO PUT ID AND DATETIME HERE. 
namespace OnlineShop.Application.Features.Categories.Commands.CreateCategory
{
    public record class CreateCategoryCommand
        (
        string Name,
        string Description 

        ) : IRequest<Guid>
    {
    }
}
