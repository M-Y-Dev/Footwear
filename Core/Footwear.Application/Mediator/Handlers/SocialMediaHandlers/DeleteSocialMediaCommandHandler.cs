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
    public class DeleteSocialMediaCommandHandler : IRequestHandler<DeleteSocialMediaCommand, Response<object>>
    {
        private readonly IRepository<SocialMedia> _repository;

        public DeleteSocialMediaCommandHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task<Response<object>> Handle(DeleteSocialMediaCommand request, CancellationToken cancellationToken)
        {
            //DeleteSocialMediaCommand valid kontrolleri yapılıyor eğer hata varsa dönecektir.
            DeleteSocialMediaCommandValidator validationRules = new DeleteSocialMediaCommandValidator();
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
                response.ResponseMessage = "Kayıt silinirken sorun yaşandı.";
                return response;
            }
            //DeleteSocialMediaCommand valid kontroll sonu 

            //requestten gelen idye göre veri araması yapıyoruz
            var value = await _repository.GetSingleByIdAsync(request.Id);

            //eğer bu id ye ait veri yoksa null dönecektir. Null kontrolü yapıyoruz.
            if (value is null)
                return new Response<object>
                {
                    ResponseStatusCode = (int)HttpStatusCode.NotFound,
                    ResponseData = null,
                    ResponseIsSuccessfull = false,
                    ResponseMessage = "Silinecek kayıt bulunamadı"
                };

            //id ye ait veri geliyorsa burada siliyoruz ve response döndürüyoruz.
            await _repository.DeleteAsync(request.Id);
            return new Response<object>
            {
                ResponseStatusCode = (int)HttpStatusCode.OK,
                ResponseData = "Kayıt silindi",
                ResponseIsSuccessfull = true,
                ResponseMessage = null,
            };


        }
    }
}
