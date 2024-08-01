using FluentValidation;
using Footwear.Application.Mediator.Commands.SocialMediaCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Validator.SocialMediaValidator
{
    public class UpdateSocialMediaCommandValidator:AbstractValidator<UpdateSocialMediaCommand>
    {
        public UpdateSocialMediaCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id boş bırakılamaz.");
            RuleFor(x => x.Icon).NotEmpty().WithMessage("Ikon boş bırakılamaz.");
            RuleFor(x => x.Url).NotEmpty().WithMessage("Url boş bırakılamaz.");
        }
    }
}
