using MediatR;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.IRepository;

namespace OnlineShop.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler :
        IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteCategoryCommandHandler
            (IUnitOfWork unitOfWork, IGenericRepository<Category> categoryRepository)
        {
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
        }
        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            Category? category = await _categoryRepository.GetByIdAsync(request.Id, cancellationToken);
            if (category == null) 
            {
                throw new KeyNotFoundException($"Couldn't find any Category with {request.Id} id");
            }
            _categoryRepository.Remove(category);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return true;
        
        }
    }
}
