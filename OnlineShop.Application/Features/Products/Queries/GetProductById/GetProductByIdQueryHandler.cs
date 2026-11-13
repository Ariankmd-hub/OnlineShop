using MediatR;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.IRepository;

namespace OnlineShop.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : 
        IRequestHandler<GetProductByIdQuery, GetProductByIdResponse?>
    {
        private readonly IGenericRepository<Product> _productRepository;
        public GetProductByIdQueryHandler(IGenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<GetProductByIdResponse?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            Product? product = await _productRepository.GetByIdAsync(request.Id, cancellationToken);
            if (product == null) 
            { return null; }
            return new GetProductByIdResponse
            {
                Id = product.Id,
                CreatedAtUtc = product.CreatedAtUtc,
                Name = product.Name,
                Description = product.Description,
                CategoryId = product.CategoryId,
                Price = product.Price,
                Stock = product.Stock,
                ImageUrl = product.ImageUrl

            };
        }
    }
}
