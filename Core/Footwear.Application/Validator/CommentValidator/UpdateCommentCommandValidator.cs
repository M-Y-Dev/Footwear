using FluentValidation;
using Footwear.Application.Mediator.Commands.CommentCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Validator.CommentValidator
{
    public class UpdateCommentCommandValidator:AbstractValidator<UpdateCommentCommand>
    {
        public UpdateCommentCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).NotEmpty().WithMessage("Id boş bırakılamaz.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email adresi boş bırakılamaz.");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık  boş bırakılamaz.");
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("Ürün boş bırakılamaz.");
            RuleFor(x => x.CommentDetail).NotEmpty().WithMessage("Yorum boş bırakılamaz.");
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("Ürün boş bırakılamaz.");
            RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Ad-Soyad boş bırakılamaz.");
        }
    }
}
