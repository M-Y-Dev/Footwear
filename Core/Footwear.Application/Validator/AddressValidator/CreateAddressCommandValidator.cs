using FluentValidation;
using Footwear.Application.Mediator.Commands.AddressCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Validator.AddressValidator
{
    public class CreateAddressCommandValidator: AbstractValidator<CreateAddressCommand>
    {
        public CreateAddressCommandValidator()
        {
            RuleFor(x => x.Country).NotEmpty().WithMessage("Ülke adı gereklidir");
            RuleFor(x => x.City).NotEmpty().WithMessage("Şehir adı gereklidir");
            RuleFor(x => x.AddressDetail).NotEmpty().WithMessage("Adres Detayı gereklidir");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Telefon Numarası gereklidir");
            RuleFor(x => x.Email).NotEmpty().WithMessage("E-posta gereklidir");
            RuleFor(x => x.WebSite).NotEmpty().WithMessage("Web Sitesi gereklidir");
        }
    }
}
