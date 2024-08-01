using AutoMapper;
using FluentValidation.Results;
using Footwear.Application.Base;
using Footwear.Application.Interfaces;
using Footwear.Application.Mediator.Commands.SocialMediaCommands;
using Footwear.Application.Validator.SocialMediaValidator;
using Footwear.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Handlers.SocialMediaHandlers
{
    public class CreateSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommand, Response<object>>
    {
        private readonly IRepository<SocialMedia> _repository;
        private readonly IMapper _mapper;

        public CreateSocialMediaCommandHandler(IRepository<SocialMedia> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<object>> Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            //CreateSocialMediaCommand valid kontrolleri yapılıyor eğer hata varsa dönecektir.
            CreateSocialMediaCommandValidator validationRules = new CreateSocialMediaCommandValidator();
            ValidationResult validation = validationRules.Validate(request);
            if (!validation.IsValid)
            {
                var response = new Response<object>();
                foreach (var item in validation.Errors)
                {
                    response.ResponseErrors.Add(item.ErrorMessage.ToString());
                }

                response.ResponseStatusCode = 400;
                response.ResponseData = null;
                response.ResponseIsSuccessfull = false;
                response.ResponseMessage = "Kayıt eklenirken sorun yaşandı.";
                return response;
            }
            //CreateSocialMediaCommand valid kontrol sonu

            //Valid hatası yok gelen bilgileri Map yapıyoruz ve SocialMedia entitisine dönüştürüyoruz.
            var result = _mapper.Map<SocialMedia>(request);

            //Yeni veri oluşturma
            await _repository.CreateAsync(result);

            //sonuç response
            return new Response<object>
            {
                ResponseStatusCode = (int)HttpStatusCode.Created,
                ResponseData = null,
                ResponseIsSuccessfull = true,
                ResponseMessage = "Kayıt başarıyla eklendi",
            };
        }
    }
}
