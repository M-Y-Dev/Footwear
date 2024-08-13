using FluentValidation;
using Footwear.Application.Mediator.Queries.BasketItemQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Validator.BasketItemValidator
{
    public class GetBasketItemByIdQueryValidator : AbstractValidator<GetBasketItemByIdQuery>
    {
        public GetBasketItemByIdQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).NotEmpty().WithMessage("Id boş bırakılamaz.");
        }
    }
}
