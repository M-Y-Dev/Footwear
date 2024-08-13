using FluentValidation;
using Footwear.Application.Mediator.Commands.ProductCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Validator.ProductValidator
{
    public class UpdateProductCommandValidator :AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).NotEmpty().WithMessage("Id boş bırakılamaz.");
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Ürün adı boş bırakılamaz.");
            RuleFor(x => x.ProductImageUrl).NotEmpty().WithMessage("Ürün resim boş bırakılamaz.");
            RuleFor(x => x.ProductStock).NotEmpty().WithMessage("Ürün stok sayısı boş bırakılamaz.");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Ürün fiyat boş bırakılamaz.");
            RuleFor(x => x.CategoryID).NotEmpty().WithMessage("Ürün kategori boş bırakılamaz.");
            RuleFor(x => x.Size).NotEmpty().WithMessage("Ayakkabı numarası boş bırakılamaz.");
            RuleFor(x => x.Color).NotEmpty().WithMessage("Ayakkabı rengi boş bırakılamaz.");
            RuleFor(x => x.IsWoman).NotEmpty().WithMessage("Bu alan boş bırakılamaz.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Lütfen bir açıklama girin.");
        }
    }
}
