using FluentValidation;
using Footwear.Application.Mediator.Commands.OrderCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Validator.OrderValidator;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("Kullanici id bos gecilemez!");
        RuleFor(x => x.OrderNumber).NotEmpty().WithMessage("Order number bos gecilemez!");
        RuleFor(x => x.ShippingAddress).NotEmpty().WithMessage("Shipping address bos gecilemez!");
    }
}
