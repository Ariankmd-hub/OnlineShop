
using MediatR;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.IRepository;

namespace OnlineShop.Application.Features.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryHandler :
        IRequestHandler<GetAllCategoriesQuery, IEnumerable<GetAllCategoriesResponse>>
    {
        private readonly IGenericRepository<Category> _categoryRepository;
        public GetAllCategoriesQueryHandler(IGenericRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<GetAllCategoriesResponse>> 
            Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Category> categories = await _categoryRepository.GetAllAsync(cancellationToken);
            var response = categories.Select(p => new GetAllCategoriesResponse
            {
                Id = p.Id,
                CreatedAtUtc = p.CreatedAtUtc,
                Name = p.Name,
                Description = p.Description,


            });
            return response;
        }
    }
}
