using FluentValidation;
using Footwear.Application.Mediator.Commands.BasketCommands;
using Footwear.Application.Mediator.Commands.CategoryCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Validator.BasketValidator
{
    public class CreateBasketCommandValidator : AbstractValidator<CreateBasketCommand>
    {
        public CreateBasketCommandValidator() 
        {
            RuleFor(x => x.UserId).GreaterThan(0).NotEmpty().WithMessage("Kullanıcı Id boş bırakılamaz.");
        }
    }
}
