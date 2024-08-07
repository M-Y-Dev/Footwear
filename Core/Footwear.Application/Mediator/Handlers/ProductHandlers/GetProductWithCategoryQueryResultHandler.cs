using AutoMapper;
using Footwear.Application.Base;
using Footwear.Application.Interfaces;
using Footwear.Application.Mediator.Queries.ProductQueries;
using Footwear.Application.Mediator.Results.ProductResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Handlers.ProductHandlers
{
    
     public class GetProductWithCategoryQueryResultHandler : IRequestHandler<GetProductWithCategoryQuery, Response<List<GetProductWithCategoryQueryResult>>>
    {
        private readonly IProductRespository _repository;
        private readonly IMapper _mapper;

        public GetProductWithCategoryQueryResultHandler(IProductRespository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        

        public async Task<Response<List<GetProductWithCategoryQueryResult>>> Handle(GetProductWithCategoryQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetProductListWithCategory();

            if (values.Any())
                return new Response<List<GetProductWithCategoryQueryResult>>
                {
                    ResponseIsSuccessfull = true,
                    ResponseData = _mapper.Map<List<GetProductWithCategoryQueryResult>>(values),
                    ResponseMessage = "Kayıtlar başarıyla getirildi",
                    ResponseStatusCode = (int)HttpStatusCode.OK,
                };
            return new Response<List<GetProductWithCategoryQueryResult>>
            {
                ResponseIsSuccessfull = false,
                ResponseData = _mapper.Map<List<GetProductWithCategoryQueryResult>>(values),
                ResponseMessage = "Listelenecek kayıt bulunamadı",
                ResponseStatusCode = (int)HttpStatusCode.NotFound,
            };
        }
    }
}