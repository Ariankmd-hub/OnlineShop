using FluentValidation;

namespace OnlineShop.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator :
        AbstractValidator<CreateProductCommand>

    {
        public CreateProductCommandValidator()
        {
            RuleFor(command => command.Name).
                NotEmpty().
                WithMessage("Name can't be null .");
            RuleFor(command => command.Description).
                NotEmpty().
                WithMessage("Description can't be null .");
            RuleFor(Command => Command.Price).
                GreaterThan(0).
                WithMessage("Price must be higher than zero .");
            RuleFor(Command => Command.Stock).
                GreaterThanOrEqualTo(0).
                WithMessage("Stock must be higher than zero");

            RuleFor(command => command.ImageUrl)
             .NotEmpty()
             .WithMessage("Image URL is required.");

            RuleFor(Command => Command.CategoryId).
               NotEmpty().
               WithMessage("Category Id Can't be empty!");

        }
    }
}
