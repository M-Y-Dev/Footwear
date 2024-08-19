using FluentValidation;
using Footwear.Application.Mediator.Commands.BrandCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Validator.BrandValidator
{
    public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
    {
        public CreateBrandCommandValidator ()
        {
            RuleFor(x=>x.ImageUrl).NotEmpty().WithMessage("Resim Kısayolu Boş Bırakılamaz");
        }
    }
}
