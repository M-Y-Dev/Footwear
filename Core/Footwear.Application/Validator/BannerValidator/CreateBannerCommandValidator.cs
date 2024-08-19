﻿using FluentValidation;
using Footwear.Application.Mediator.Commands.BannerCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Validator.BannerValidator
{
    public class CreateBannerCommandValidator :AbstractValidator<CreateBannerCommand>
    {
        public CreateBannerCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş bırakılamaz.");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim yolu boş bırakılamaz.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş bırakılamaz.");
        }

    }
}
