using FluentValidation;
using Footwear.Application.Mediator.Commands.AboutCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Validator.AboutValidator
{
    public class DeleteAboutCommandValidator : AbstractValidator<DeleteAboutCommand>
    {
        public DeleteAboutCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).NotEmpty().WithMessage("Id boş bırakılamaz.");
        }
    }
}
