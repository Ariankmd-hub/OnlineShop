using MediatR;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.IRepository;

namespace OnlineShop.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler :
        IRequestHandler<GetAllProductsQuery, IEnumerable<GetAllProductsResponse>>
    {
        private readonly IGenericRepository<Product> _productRepository;

        public GetAllProductsQueryHandler(IGenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<GetAllProductsResponse>> 
            Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Product> products = await _productRepository.GetAllAsync(cancellationToken);
            var response = products.Select(p => new GetAllProductsResponse
            {
                Id = p.Id,
                CreatedAtUtc = p.CreatedAtUtc,
                Name = p.Name,
                Price = p.Price,
                Description = p.Description,
                Stock = p.Stock,
                ImageUrl = p.ImageUrl,
                CategoryId = p.CategoryId
            });
            return response;
        }
    }
}
