using MediatR;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.IRepository;

namespace OnlineShop.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork,
            IGenericRepository<Product> productRepository)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }
        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            // id and create at utc autpmaticlly will fill.
            Product product = new Product()
            {
                CategoryId = request.CategoryId,
                Name = request.Name,
                Stock = request.Stock,
                Price = request.Price,
                ImageUrl = request.ImageUrl,
                Description = request.Description
            };

            await _productRepository.AddAsync(product, cancellationToken);
            
                
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return product.Id;
           
        }
    }
}
