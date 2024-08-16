using FluentValidation;
using Footwear.Application.Mediator.Commands.OrderCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Validator.OrderValidator;

public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
{
    public DeleteOrderCommandValidator()
    {
        RuleFor(x=> x.Id).GreaterThan(0).NotEmpty().WithMessage("Id cannot be empty or negative!");
    }
}
