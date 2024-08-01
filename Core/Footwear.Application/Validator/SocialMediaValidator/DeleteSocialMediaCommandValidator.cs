using FluentValidation;
using Footwear.Application.Mediator.Commands.SocialMediaCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Validator.SocialMediaValidator
{
    public class DeleteSocialMediaCommandValidator:AbstractValidator<DeleteSocialMediaCommand>
    {
        public DeleteSocialMediaCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).NotEmpty().WithMessage("Id boş bırakılamaz.");
        }
    }
}
