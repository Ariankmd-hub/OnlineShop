using MediatR;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.IRepository;

namespace OnlineShop.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand,Guid>
    {
        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateCategoryCommandHandler
            (IUnitOfWork unitOfWork, IGenericRepository<Category> categoryRepository)
        {
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
        }

        public async Task<Guid>
            Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = new Category()
            {
                Name = request.Name,
                Description = request.Description
            };
            await _categoryRepository.AddAsync(category,cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return category.Id;
        }
    }
}
