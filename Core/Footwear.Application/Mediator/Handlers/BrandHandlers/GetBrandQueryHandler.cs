using AutoMapper;
using Footwear.Application.Base;
using Footwear.Application.Interfaces;
using Footwear.Application.Mediator.Queries.BrandQueries;
using Footwear.Application.Mediator.Results.BrandResults;
using Footwear.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Handlers.BrandHandlers
{
    public class GetBrandQueryResultHandler : IRequestHandler<GetBrandQuery, Response<List<GetBrandQueryResult>>>
    {
        private readonly IRepository<Brand> _repository;
        private readonly IMapper _mapper;

        public GetBrandQueryResultHandler ( IRepository<Brand> repository, IMapper mapper )
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<List<GetBrandQueryResult>>> Handle ( GetBrandQuery request, CancellationToken cancellationToken )
        {
            var values = await _repository.GetAllAsync();
            if (values.Any())
                return new Response<List<GetBrandQueryResult>>
                {
                    ResponseIsSuccessfull = true,
                    ResponseData = _mapper.Map<List<GetBrandQueryResult>>(values),
                    ResponseMessage = "Kayıtlar başarıyla getirildi",
                    ResponseStatusCode = (int)HttpStatusCode.OK,
                };
            return new Response<List<GetBrandQueryResult>>
            {
                ResponseIsSuccessfull = false,
                ResponseData = _mapper.Map<List<GetBrandQueryResult>>(values),
                ResponseMessage = "Listelenecek kayıt bulunamadı",
                ResponseStatusCode = (int)HttpStatusCode.NotFound,
            };
        }
    }
}
