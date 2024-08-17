using FluentValidation;
using Footwear.Application.Mediator.Queries.OrderQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Validator.OrderValidator;

public class GetOrderByIdQueryValidator :  AbstractValidator<GetOrderByIdQuery>
{
    public GetOrderByIdQueryValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).NotEmpty().WithMessage("Id cannot be empty or negative!");
    }
}
