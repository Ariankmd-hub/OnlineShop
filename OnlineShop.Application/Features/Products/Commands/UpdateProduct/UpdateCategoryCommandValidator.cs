using FluentValidation;

namespace OnlineShop.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator
        : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(command => command.Id)
                .NotEmpty()
                .WithMessage("Product ID is required.");

            RuleFor(command => command.Name)
                .NotEmpty()
                .WithMessage("Name is required.");

            RuleFor(command => command.Price)
                .GreaterThan(0)
                .WithMessage("Price must be greater than zero.");

            RuleFor(command => command.Description)
                .NotEmpty()
                .WithMessage("Description is required.");

            RuleFor(command => command.Stock)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Stock cannot be negative.");

            RuleFor(command => command.ImageUrl)
                .NotEmpty()
                .WithMessage("Image URL is required.");

            RuleFor(command => command.CategoryId)
                .NotEmpty()
                .WithMessage("Category ID is required.");
        }
    }
}
