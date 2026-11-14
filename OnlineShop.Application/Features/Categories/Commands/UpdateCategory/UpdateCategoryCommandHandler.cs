using MediatR;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.IRepository;

namespace OnlineShop.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler :
        IRequestHandler<UpdateCategoryCommand, Guid>
    {
        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateCategoryCommandHandler
            (IUnitOfWork unitOfWork, IGenericRepository<Category> categoryRepository)
        {
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
        }

        public async Task<Guid> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category? category = await _categoryRepository.GetByIdAsync(request.Id, cancellationToken);
            if (category == null) 
            {
                throw new KeyNotFoundException($"Couldn't  find a Category with {request.Id} id ");
            }
            category.Name = request.Name;
            category.Description = request.Description;
            category.UpdatedAtUtc = DateTime.UtcNow;
            _categoryRepository.Update(category);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return category.Id;

        
        }
    }
}
