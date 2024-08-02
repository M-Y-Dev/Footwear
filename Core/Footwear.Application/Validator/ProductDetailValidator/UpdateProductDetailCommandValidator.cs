using FluentValidation;
using Footwear.Application.Mediator.Commands.ProductDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Validator.ProductDetailValidator
{
    public class UpdateProductDetailCommandValidator : AbstractValidator<UpdateProductDetailCommand>
    {
        public UpdateProductDetailCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).NotEmpty().WithMessage("Id boş bırakılamaz.");
            RuleFor(x => x.ProductInfo).NotEmpty().WithMessage("Ürün bilgi alanı boş bırakılamaz.");
            RuleFor(x => x.Rating).NotEmpty().WithMessage("Ürün puanı boş  bırakılamaz.");
            RuleFor(x => x.ImageUrlDetail1).NotEmpty().WithMessage("Ürün resim alanı boş bırakılamaz.");
            RuleFor(x => x.ImageUrlDetail2).NotEmpty().WithMessage("Ürün resim alanı boş bırakılamaz.");
            RuleFor(x => x.ImageUrlDetail3).NotEmpty().WithMessage("Ürün resim alanı boş bırakılamaz.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Ürün açıklama boş bırakılamaz.");
            RuleFor(x => x.CompanyInformation).NotEmpty().WithMessage("Ürün şirket bilgisi boş bırakılamaz.");
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("Ürün adı boş bırakılamaz.");
        }
    }
}
