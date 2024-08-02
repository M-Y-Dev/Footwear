using FluentValidation;
using Footwear.Application.Mediator.Queries.AboutQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Validator.AboutValidator
{
    public class GetAboutByIdQueryValidator:AbstractValidator<GetAboutByIdQuery>
    {
        public GetAboutByIdQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).NotEmpty().WithMessage("Id boş bırakılamaz.");

        }
    }
}
