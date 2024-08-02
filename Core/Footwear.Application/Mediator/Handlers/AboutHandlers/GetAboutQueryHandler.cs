using AutoMapper;
using Footwear.Application.Base;
using Footwear.Application.Interfaces;
using Footwear.Application.Mediator.Queries.AboutQueries;
using Footwear.Application.Mediator.Results.AboutResults;
using Footwear.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Handlers.AboutHandlers
{
    public class GetAboutQueryHandler : IRequestHandler<GetAboutQuery,Response<List<GetAboutQueryResult>>>
    {
        private readonly IRepository<About> _repository;
        private readonly IMapper _mapper;

        public GetAboutQueryHandler(IRepository<About> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<List<GetAboutQueryResult>>> Handle(GetAboutQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            if (values.Any())
                return new Response<List<GetAboutQueryResult>>
                {
                    ResponseIsSuccessfull = true,
                    ResponseData = _mapper.Map<List<GetAboutQueryResult>>(values),
                    ResponseMessage = "Kayıtlar başarıyla getirildi",
                    ResponseStatusCode = (int)HttpStatusCode.OK
                };
            return new Response<List<GetAboutQueryResult>>
            {
                ResponseIsSuccessfull = false,
                ResponseData = _mapper.Map<List<GetAboutQueryResult>>(values),
                ResponseMessage = "Listelenecek kayıt bulunamadı",
                ResponseStatusCode = (int)HttpStatusCode.NotFound,
            };
        }
    }
}
