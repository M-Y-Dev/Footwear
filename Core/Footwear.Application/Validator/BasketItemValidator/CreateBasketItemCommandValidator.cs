using FluentValidation;
using Footwear.Application.Mediator.Commands.BasketItemCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Validator.BasketItemValidator
{
    public class CreateBasketItemCommandValidator : AbstractValidator<CreateBasketItemCommand>
    {
        public CreateBasketItemCommandValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("Ürün Id boş geçilemez.");

            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Ürün Adı boş bırakılamaz.");

            RuleFor(x => x.Quantity)
                .NotEmpty().WithMessage("Miktar boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Miktar 0'dan büyük olmalıdır.");

            RuleFor(x => x.UnitPrice)
                .NotEmpty().WithMessage("Birim Fiyat boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Birim Fiyat 0'dan büyük olmalıdır.");

            RuleFor(x => x.TotalPrice)
                .NotEmpty().WithMessage("Toplam Fiyat boş bırakılamaz.")
                .GreaterThan(0).WithMessage("Toplam Fiyat 0'dan büyük olmalıdır.");
        }
    }
}
