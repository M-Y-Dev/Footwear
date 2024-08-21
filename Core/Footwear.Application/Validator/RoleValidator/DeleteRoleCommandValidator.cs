using FluentValidation;
using Footwear.Application.Mediator.Commands.RoleCommands;

namespace Footwear.Application.Validator.RoleValidator
{
    public class DeleteRoleCommandValidator : AbstractValidator<DeleteRoleCommand>
    {
        public DeleteRoleCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).NotEmpty().WithMessage("Id boş bırakılamaz.");
        }
    }
}
