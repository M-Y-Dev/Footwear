using FluentValidation;
using Footwear.Application.Mediator.Queries.ContactQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Validator.ContactValidator
{
    public class GetContactByIdQueryValidator : AbstractValidator<GetContactByIdQuery>
    {
        public GetContactByIdQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).NotEmpty().WithMessage("Id boş bırakılamaz.");
        }
    }
}
