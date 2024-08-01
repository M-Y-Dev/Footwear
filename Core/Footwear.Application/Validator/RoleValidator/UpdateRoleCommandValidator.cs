using FluentValidation;
using Footwear.Application.Mediator.Commands.RoleCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Validator.RoleValidator
{
    public class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
    {
        public UpdateRoleCommandValidator()
        {
            RuleFor(x => x.RoleName).NotEmpty().WithMessage("Rol adı boş geçilemez");
            RuleFor(x => x.RoleName).MinimumLength(5).WithMessage("Rol adı minimum 5 karakterden oluşmalıdır.");
            RuleFor(x => x.RoleName).MaximumLength(15).WithMessage("Rol adı maksimum 15 karakterden oluşmalıdır");
        }
    }
}
