using FluentValidation;
using Footwear.Application.Mediator.Commands.AboutCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Validator.AboutValidator
{
    public class UpdateAboutCommandValidator:AbstractValidator<UpdateAboutCommand>
    {
        public UpdateAboutCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).NotEmpty().WithMessage("Id boş bırakılamaz.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama kısmı boş bırakılamaz.");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık  boş bırakılamaz.");
            RuleFor(x => x.VideoUrl).NotEmpty().WithMessage("Video Url boş bırakılamaz.");
        }
    }
}
