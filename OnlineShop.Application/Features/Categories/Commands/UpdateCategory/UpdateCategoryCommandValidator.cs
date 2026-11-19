using FluentValidation;

namespace OnlineShop.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandValidator
        : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(command => command.Id)
                .NotEmpty()
                .WithMessage("Category ID is required.");

            RuleFor(command => command.Name)
                .NotEmpty()
                .WithMessage("Name is required.");

            RuleFor(command => command.Description)
                .NotEmpty()
                .WithMessage("Description is required.");
        }
    }
}
