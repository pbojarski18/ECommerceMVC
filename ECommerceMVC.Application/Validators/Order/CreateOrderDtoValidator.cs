using ECommerceMVC.Application.Dtos.Orders;
using FluentValidation;

namespace ECommerceMVC.Application.Validators.Order;

public class CreateOrderDtoValidator : AbstractValidator<CreateOrderDto>
{
    public CreateOrderDtoValidator()
    {
        RuleFor(p => p.UserId)
            .NotEmpty().WithMessage("UserId can't  be empty");
        RuleFor(p => p.AddressId)
            .NotEmpty().WithMessage("AddressId can't be empty");
    }
}