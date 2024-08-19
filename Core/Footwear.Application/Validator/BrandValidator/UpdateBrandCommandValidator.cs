using FluentValidation;
using Footwear.Application.Mediator.Commands.BrandCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Validator.BrandValidator
{
    public class UpdateBrandCommandValidator : AbstractValidator<UpdateBrandCommand>
    {
        public UpdateBrandCommandValidator ()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id Boş Bırakılamaz");
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim boş bırakılamaz.");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim Kısayolu Boş Bırakılamaz");
            
        }
    }
}
