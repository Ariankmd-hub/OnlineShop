using MediatR;
using OnlineShop.Application.Features.Categories.Queries.GetAllCategories;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.IRepository;

namespace OnlineShop.Application.Features.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryHandler :
        IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdResponse?>
    {
        private readonly IGenericRepository<Category> _categoryRepository;
        public GetCategoryByIdQueryHandler(IGenericRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }



        public async Task<GetCategoryByIdResponse?> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            Category? category = await _categoryRepository.GetByIdAsync(request.Id, cancellationToken);
            if (category == null) { return null; }
            var response = new GetCategoryByIdResponse
            {
                Id = category.Id,
                CreatedAtUtc = category.CreatedAtUtc,
                Name = category.Name,
                Description = category.Description
            };
            return response;
        }
    }
}
