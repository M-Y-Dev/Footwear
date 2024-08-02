using FluentValidation;
using Footwear.Application.Mediator.Queries.ProductDetailQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Validator.ProductDetailValidator
{
    public class GetProductDetailByIdQueryValidator : AbstractValidator<GetProductDetailByIdQuery>
    {
        public GetProductDetailByIdQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).NotEmpty().WithMessage("Id boş bırakılamaz.");
        }
    }
}
