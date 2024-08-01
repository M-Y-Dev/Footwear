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
    public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand, Response<object>>
    {
        private readonly IRepository<SocialMedia> _repository;
        private readonly IMapper _mapper;

        public UpdateSocialMediaCommandHandler(IRepository<SocialMedia> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<object>> Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            //UpdateSocialMediaCommand valid kontrolleri yapılıyor eğer hata varsa dönecektir.
            UpdateSocialMediaCommandValidator validationRules = new UpdateSocialMediaCommandValidator();
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
                response.ResponseMessage = "Kayıt güncellenirken sorun yaşandı.";
                return response;
            }
            //UpdateSocialMediaCommand valid kontrol sonu

            //requetten gelen id ye göre veri arıyoruz.
            var value = await _repository.GetById(request.Id);

            //eğer bu idye ait veri yoksa null dönecektir onun kontrolünü yapıyoruz.
            if (value is null)
                return new Response<object>
                {
                    ResponseStatusCode = (int)HttpStatusCode.NotFound,
                    ResponseData=null,
                    ResponseIsSuccessfull=false,
                    ResponseMessage="Aranılan kayıt bulunamadı"
                };

            // value null değil ise burada mapper ile güncelleme yapıyoruz(burası herkes için yeni kod örneği)
            _mapper.Map(request,value);

            //güncelleme işlemini yapıyoruz
            await _repository.UpdateAsync(value);

            //başarılı response dönüyoruz.
            return new Response<object>
            {
                ResponseStatusCode = (int)HttpStatusCode.OK,
                ResponseData = null,
                ResponseIsSuccessfull = true,
                ResponseMessage = "Kayıt güncellendi"
            };
        }
    }
}
