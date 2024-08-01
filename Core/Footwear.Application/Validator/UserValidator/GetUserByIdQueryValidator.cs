using FluentValidation;
using Footwear.Application.Mediator.Queries.UserQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Validator.UserValidator
{
    public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
    {
        public GetUserByIdQueryValidator()
        {
            RuleFor(x => x.UserId).GreaterThan(0).NotEmpty().WithMessage("Id boş bırakılamaz.");
        }
    }
}
