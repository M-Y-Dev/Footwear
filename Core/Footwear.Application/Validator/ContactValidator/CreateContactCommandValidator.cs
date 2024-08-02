using FluentValidation;
using Footwear.Application.Mediator.Commands.ContactCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Validator.ContactValidator
{
    public class CreateContactCommandValidator: AbstractValidator<CreateContactCommand>
    {
        public CreateContactCommandValidator()
        {

            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Tam ad zorunludur.")
                .MaximumLength(100).WithMessage("Tam ad 100 karakteri geçemez.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta adresi zorunludur.")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");

            RuleFor(x => x.Subject)
                .NotEmpty().WithMessage("Konu zorunludur.")
                .MaximumLength(150).WithMessage("Konu 150 karakteri geçemez.");

            RuleFor(x => x.Message)
                .NotEmpty().WithMessage("Mesaj zorunludur.")
                .MaximumLength(1000).WithMessage("Mesaj 1000 karakteri geçemez.");
        }
    }
}
