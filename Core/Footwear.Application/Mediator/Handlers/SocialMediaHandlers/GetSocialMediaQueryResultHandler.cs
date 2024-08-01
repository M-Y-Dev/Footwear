using AutoMapper;
using Footwear.Application.Base;
using Footwear.Application.Interfaces;
using Footwear.Application.Mediator.Queries.SocialMediaQueries;
using Footwear.Application.Mediator.Results.SocialMediaResults;
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
    public class GetSocialMediaQueryResultHandler : IRequestHandler<GetSocialMediaQuery, Response<List<GetSocialMediaQueryResult>>>
    {
        private readonly IRepository<SocialMedia> _repository;
        private readonly IMapper _mapper;

        public GetSocialMediaQueryResultHandler(IRepository<SocialMedia> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<List<GetSocialMediaQueryResult>>> Handle(GetSocialMediaQuery request, CancellationToken cancellationToken)
        {
            //tüm socialmedia listesini istiyoruz.
            var values = await _repository.GetAllAsync();

            //eğer içerisinde hiç bir veri varsa başarılı döndürüyoruz
            if(values.Any())
                return new Response<List<GetSocialMediaQueryResult>>
                {
                    ResponseIsSuccessfull=true,
                    ResponseData = _mapper.Map<List<GetSocialMediaQueryResult>>(values),
                    ResponseMessage="Kayıtlar başarıyla getirildi",
                    ResponseStatusCode=(int)HttpStatusCode.OK,
                };
            //values.any()den return dönmezse burası çalışır ve kayıt bulamamış demektir.
            return new Response<List<GetSocialMediaQueryResult>>
            {
                ResponseIsSuccessfull = false,
                ResponseData = _mapper.Map<List<GetSocialMediaQueryResult>>(values),
                ResponseMessage = "Listelenecek kayıt bulunamadı",
                ResponseStatusCode = (int)HttpStatusCode.NotFound,
            };
        }
    }
}
