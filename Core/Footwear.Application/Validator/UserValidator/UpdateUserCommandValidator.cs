using FluentValidation;
using Footwear.Application.Mediator.Commands.UserCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Validator.UserValidator
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            
        }
    }
}
