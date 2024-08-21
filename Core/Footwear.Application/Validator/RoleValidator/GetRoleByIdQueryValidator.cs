using FluentValidation;
using Footwear.Application.Mediator.Queries.RoleQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Validator.RoleValidator
{
    public class GetRoleByIdQueryValidator : AbstractValidator<GetRoleByIdQuery>
    {
        public GetRoleByIdQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).NotEmpty().WithMessage("Id boş bırakılamaz.");
        }
    }
}
