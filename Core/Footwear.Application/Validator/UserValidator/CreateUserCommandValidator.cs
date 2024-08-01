using FluentValidation;
using Footwear.Application.Mediator.Commands.UserCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Validator.UserValidator
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("İsim boş geçilemez");
            RuleFor(x => x.FirstName).MinimumLength(3).WithMessage("İsim 3 karakterden az olamaz");
            RuleFor(x => x.FirstName).MaximumLength(15).WithMessage("İsim 15 karakterden fazla olamaz");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyisim boş geçilemez");
            RuleFor(x => x.LastName).MinimumLength(3).WithMessage("Soyisim 3 karakterden az olamaz");
            RuleFor(x => x.LastName).MaximumLength(15).WithMessage("Soyisim 15 karakterden fazla olamaz");

            RuleFor(x => x.Email).NotEmpty().WithMessage("E-Posta boş geçilemez");
            RuleFor(x => x.Email).EmailAddress().WithMessage("E-posta geçerli bir adress olmalıdır");

            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez");
            RuleFor(x => x.UserName).MinimumLength(5).WithMessage("Kullanıcı adı uzunluğu 5 karakterden kısa olamaz.");
            RuleFor(x => x.UserName).MaximumLength(20).WithMessage("Kullanıcı adı uzunluğu 20 karakterden uzun olamaz.");

            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Telefon numarası boş geçilemez");
            RuleFor(x => x.PhoneNumber).Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Lütfen geçerli bir telefon numarası yazınız.");

            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Görsel alan boş geçilemez");

            RuleFor(x => x.RoleId).NotEmpty().WithMessage("Rol ataması boş geçilemez");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı boş geçilemez");
            RuleFor(x => x.Password).MinimumLength(8).WithMessage("Şifre uzunluğu en az 8 karakterden oluşmalıdır");
            RuleFor(x => x.Password).MaximumLength(24).WithMessage("Şifre uzunluğu en fazla 24 karakterden oluşmalıdır");
            RuleFor(x => x.Password).Matches(@"[A-Z]").WithMessage("Şifre en az 1 büyük harf içermelidir.");
            RuleFor(x => x.Password).Matches(@"[0-9]").WithMessage("Şifre en az 1 rakam içermelidir.");
            RuleFor(x => x.Password).Matches(@"[\W]").WithMessage("Şifre en az 1 özel karakter içermelidir.");

        }
    }
}
