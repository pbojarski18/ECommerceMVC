using ECommerceMVC.Application.Dtos.Products;
using FluentValidation;

namespace ECommerceMVC.Application.Validators.Product;

public class ProductDtoValidator : AbstractValidator<ProductDto>
{
    public ProductDtoValidator()
    {
        RuleFor(p => p.Name)
            .Length(5, 50).WithMessage("Name should be between 5 n 50 characters")
            .NotEmpty().WithMessage("Name can't be empty");
        RuleFor(p => p.Price)
            .GreaterThan(0).WithMessage("Price has to be greather than 0")
            .NotEmpty().WithMessage("Can't be empty");
        RuleFor(p => p.Description)
            .Length(50, 1000).WithMessage("Description should be between 50 n 1000 characters")
            .NotEmpty().WithMessage("Can't be empty");
        RuleFor(p => p.ImagePath)
            .NotEmpty().WithMessage("Can't be empty");
        RuleFor(p => p.Brand)
            .MaximumLength(20).WithMessage("Brand should be max 20 characters")
            .NotEmpty().WithMessage("Can't be empty");
    }
}
