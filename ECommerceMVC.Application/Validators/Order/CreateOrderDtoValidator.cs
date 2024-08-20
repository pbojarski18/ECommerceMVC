using ECommerceMVC.Application.Dtos.Orders;
using FluentValidation;
using System.Text.RegularExpressions;

namespace ECommerceMVC.Application.Validators.Order;

public class CreateOrderDtoValidator : AbstractValidator<CreateOrderDto>
{
    public CreateOrderDtoValidator()
    {
        RuleFor(p => p.UserFirstName)
            .NotEmpty().WithMessage("First name can't be empty");
        RuleFor(p => p.UserLastName)
            .NotEmpty().WithMessage("Last name can't be empty");
        RuleFor(p => p.UserEmail).EmailAddress().WithMessage("Email must be in format email@email.com")
            .NotEmpty().WithMessage("Email can't be empty");
        RuleFor(p => p.UserAddress)
            .NotEmpty().WithMessage("Address can't be empty");
        RuleFor(p => p.UserCity)
            .NotEmpty().WithMessage("City can't be empty");
        RuleFor(p => p.PhoneNumber)
            .Length(9).WithMessage("Number must contain 9 characters")
            .NotEmpty().WithMessage("Number can't be empty");
        RuleFor(p => p.PostalCode).Must(PostalCodeFormat).WithMessage("Postal code must be in format 11-111")
            .NotEmpty().WithMessage("Postal code can't be empty");

    }

    private bool PostalCodeFormat(string postalCode)
    {
        var pattern = @"^\d{2}-\d{3}$";
        return Regex.IsMatch(postalCode, pattern);
    }
}
