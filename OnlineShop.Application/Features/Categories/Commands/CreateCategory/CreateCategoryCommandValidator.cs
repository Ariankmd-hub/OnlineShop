using FluentValidation;

namespace OnlineShop.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator
        : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(command => command.Name)
                .NotEmpty()
                .WithMessage("Name is required.");

            RuleFor(command => command.Description)
                .NotEmpty()
                .WithMessage("Description is required.");
        }
    }
}
