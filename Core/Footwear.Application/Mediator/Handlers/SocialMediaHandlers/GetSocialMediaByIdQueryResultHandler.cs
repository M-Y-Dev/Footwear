using AutoMapper;
using FluentValidation.Results;
using Footwear.Application.Base;
using Footwear.Application.Interfaces;
using Footwear.Application.Mediator.Queries.SocialMediaQueries;
using Footwear.Application.Mediator.Results.SocialMediaResults;
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
    public class GetSocialMediaByIdQueryResultHandler : IRequestHandler<GetSocialMediaByIdQuery, Response<GetSocialMediaByIdQueryResult>>
    {
        private readonly IRepository<SocialMedia> _repository;
        private readonly IMapper _mapper;

        public GetSocialMediaByIdQueryResultHandler(IRepository<SocialMedia> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<GetSocialMediaByIdQueryResult>> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
        {
            //DeleteSocialMediaCommand valid kontrolleri yapılıyor eğer hata varsa dönecektir.
            GetSocialMediaByIdQueryValidator validationRules = new GetSocialMediaByIdQueryValidator();
            ValidationResult validation = validationRules.Validate(request);
            if (!validation.IsValid)
            {
                var response = new Response<GetSocialMediaByIdQueryResult>();
                foreach (var item in validation.Errors)
                {
                    response.ResponseErrors.Add(item.ErrorMessage.ToString());
                }

                response.ResponseStatusCode = 400;
                response.ResponseData = new GetSocialMediaByIdQueryResult();
                response.ResponseIsSuccessfull = false;
                response.ResponseMessage = "Kayıt getirilirken sorun yaşandı.";
                return response;
            }
            //DeleteSocialMediaCommand valid kontrol sonu

            //requestten gelen id ye göre veri araması
            var value = await _repository.GetById(request.Id);

            //eğer bu id ye ait veri yoksa null dönecektir. Null kontrolü yapıyoruz.
            if (value is null)
                return new Response<GetSocialMediaByIdQueryResult>
                {
                    ResponseStatusCode = (int)HttpStatusCode.NotFound,
                    ResponseData=null,
                    ResponseIsSuccessfull=false,
                    ResponseMessage="Kayıt bulunamadı"
                };
            //id ye ait veri geliyor ve response döndürüyoruz.
            return new Response<GetSocialMediaByIdQueryResult>
            {
                ResponseStatusCode = (int)HttpStatusCode.OK,
                ResponseData = _mapper.Map<GetSocialMediaByIdQueryResult>(value),
                ResponseIsSuccessfull=true,
                ResponseMessage="Kayıt başarıyla getirildi"
            };
        }
    }
}
