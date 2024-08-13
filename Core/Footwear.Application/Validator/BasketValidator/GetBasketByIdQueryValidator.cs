using FluentValidation;
using Footwear.Application.Mediator.Queries.BasketQueries;
using Footwear.Application.Mediator.Queries.CategoryQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Validator.BasketValidator
{
    public class GetBasketByIdQueryValidator : AbstractValidator<GetBasketByIdQuery>
    {
        public GetBasketByIdQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).NotEmpty().WithMessage("Id boş bırakılamaz.");
        }
    }
}
