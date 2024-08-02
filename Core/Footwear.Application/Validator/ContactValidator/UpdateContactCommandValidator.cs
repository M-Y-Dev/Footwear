using FluentValidation;
using Footwear.Application.Mediator.Commands.ContactCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Validator.ContactValidator
{
    public class UpdateContactCommandValidator: AbstractValidator<UpdateContactCommand>
    {
        public UpdateContactCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).NotEmpty().WithMessage("Id boş bırakılamaz.");
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Tam isim boş bırakılamaz.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş bırakılamaz.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu boş bırakılamaz.");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj boş bırakılamaz.");
        }
    }
}
