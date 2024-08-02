using FluentValidation;
using Footwear.Application.Mediator.Commands.CategoryCommands;
using Footwear.Application.Mediator.Commands.ProductCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Validator.CategoryValidator
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator() 
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adı boş bırakılamaz.");
        }
    }
}
