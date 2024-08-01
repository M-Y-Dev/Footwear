using FluentValidation;
using Footwear.Application.Mediator.Commands.SocialMediaCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Validator.SocialMediaValidator
{
    public class CreateSocialMediaCommandValidator:AbstractValidator<CreateSocialMediaCommand>
    {
        public CreateSocialMediaCommandValidator()
        {
            RuleFor(x => x.Icon).NotEmpty().WithMessage("Ikon boş bırakılamaz.");
            RuleFor(x => x.Url).NotEmpty().WithMessage("Url boş bırakılamaz.");
        }
    }
}
