using FluentValidation;
using Footwear.Application.Mediator.Queries.CommentQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Validator.CommentValidator
{
    public class GetCommentByIdQueryValidator:AbstractValidator<GetCommentByIdQuery>
    {
        public GetCommentByIdQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).NotEmpty().WithMessage("Id boş bırakılamaz.");
        }
    }
}
