using FluentValidation;
using Footwear.Application.Mediator.Queries.BrandQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Validator.BrandValidator
{
    public class DeleteBrandCommandValidator : AbstractValidator<GetBrandByIdQuery>
    {
        public DeleteBrandCommandValidator ()
        {
            RuleFor(x => x.Id).GreaterThan(0).NotEmpty().WithMessage("Id boş bırakılamaz.");
        }
    }
   
}
