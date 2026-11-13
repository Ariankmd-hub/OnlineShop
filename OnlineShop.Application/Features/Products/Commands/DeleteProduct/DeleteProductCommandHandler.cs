using MediatR;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.IRepository;

namespace OnlineShop.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteProductCommandHandler(
            IGenericRepository<Product> productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            Product? product =await _productRepository.GetByIdAsync(request.Id, cancellationToken);
            
            if (product == null) 
            { throw new KeyNotFoundException($"Product with ID '{request.Id}' was not found."); }

            _productRepository.Remove(product);
            
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return true ;
        }
    }
}
