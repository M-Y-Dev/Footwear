using AutoMapper;
using Footwear.Application.Base;
using Footwear.Application.Interfaces;
using Footwear.Application.Mediator.Queries.CategoryQueries;
using Footwear.Application.Mediator.Results.CategoryResults;
using Footwear.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Handlers.CategoryHandlers
{
    public class GetCategoryQueryResultHandler : IRequestHandler<GetCategoryQuery, Response<List<GetCategoryQueryResult>>>
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public GetCategoryQueryResultHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<List<GetCategoryQueryResult>>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            if (values.Any())
                return new Response<List<GetCategoryQueryResult>>
                {
                    ResponseIsSuccessfull = true,
                    ResponseData = _mapper.Map<List<GetCategoryQueryResult>>(values),
                    ResponseMessage = "Kayıtlar başarıyla getirildi",
                    ResponseStatusCode = (int)HttpStatusCode.OK,
                };
            return new Response<List<GetCategoryQueryResult>>
            {
                ResponseIsSuccessfull = false,
                ResponseData = _mapper.Map<List<GetCategoryQueryResult>>(values),
                ResponseMessage = "Listelenecek kayıt bulunamadı",
                ResponseStatusCode = (int)HttpStatusCode.NotFound,
            };
        }
    }
}
