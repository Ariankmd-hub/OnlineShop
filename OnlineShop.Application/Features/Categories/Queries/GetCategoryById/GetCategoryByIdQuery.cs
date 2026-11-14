using MediatR;

namespace OnlineShop.Application.Features.Categories.Queries.GetCategoryById
{
    public record class GetCategoryByIdQuery(Guid Id) : IRequest<GetCategoryByIdResponse?>
    {
    }
}
