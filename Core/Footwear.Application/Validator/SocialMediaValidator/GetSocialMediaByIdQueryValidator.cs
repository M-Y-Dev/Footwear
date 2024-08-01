using FluentValidation;
using Footwear.Application.Mediator.Queries.SocialMediaQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Validator.SocialMediaValidator
{
    public class GetSocialMediaByIdQueryValidator:AbstractValidator<GetSocialMediaByIdQuery>
    {
        public GetSocialMediaByIdQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).NotEmpty().WithMessage("Id boş bırakılamaz.");
        }
    }
}
