using FluentValidation;
using Footwear.Application.Mediator.Commands.ProductCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Validator.ProductValidator
{
    public class CreateProductCommandValidator :AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Ürün adı boş bırakılamaz.");
            RuleFor(x => x.ProductImageUrl).NotEmpty().WithMessage("Ürün resim boş bırakılamaz.");
            RuleFor(x => x.ProductStock).NotEmpty().WithMessage("Ürün stok sayısı boş bırakılamaz.");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Ürün fiyat boş bırakılamaz.");
            RuleFor(x => x.CategoryID).NotEmpty().WithMessage("Ürün kategori boş bırakılamaz.");
        }
    }
}
