using FluentValidation;
using Footwear.Application.Mediator.Commands.RoleCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Validator.RoleValidator
{
    public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommandValidator()
        {
            RuleFor(x => x.RoleName).NotEmpty().WithMessage("Rol adı boş geçilemez.");
            RuleFor(x => x.RoleName).MinimumLength(5).WithMessage("Rol 5 karakterden kısa içeriğe sahip olamaz.");
            RuleFor(x => x.RoleName).MaximumLength(15).WithMessage("Rol 15 karakterden uzun içeriğe sahip olamaz.");
            RuleFor(x => x.RoleName).Matches(@"^[a-zA-Z]+$").WithMessage("Rol adı sadece harflerden oluşmalıdır.");
        }
    }
}
