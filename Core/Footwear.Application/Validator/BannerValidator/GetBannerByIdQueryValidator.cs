using FluentValidation;
using Footwear.Application.Mediator.Queries.BannerQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Validator.BannerValidator
{
    public class GetBannerByIdQueryValidator:AbstractValidator<GetBannerByIdQuery>
    {
        public GetBannerByIdQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).NotEmpty().WithMessage("Id boş bırakılamaz.");
        }
    }
}
