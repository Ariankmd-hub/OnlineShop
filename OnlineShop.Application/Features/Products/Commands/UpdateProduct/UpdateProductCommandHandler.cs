using MediatR;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.IRepository;

namespace OnlineShop.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Guid>
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateProductCommandHandler(
            IGenericRepository<Product> productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Product? product = await _productRepository.GetByIdAsync(request.Id, cancellationToken);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID '{request.Id}' was not found.");
            }
            product.Name = request.Name;
            product.Description = request.Description;
            product.CategoryId = request.CategoryId;
            product.ImageUrl = request.ImageUrl;
            product.UpdatedAtUtc = DateTime.UtcNow;
            product.Stock = request.Stock;
            product.Price = request.Price;

            _productRepository.Update(product);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return product.Id;

        }
    }
}
