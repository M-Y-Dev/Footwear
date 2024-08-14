using AutoMapper;
using Footwear.Application.Base;
using Footwear.Application.Interfaces;
using Footwear.Application.Mediator.Queries.ProductQueries;
using Footwear.Application.Mediator.Results.ProductResults;
using Footwear.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Handlers.ProductHandlers
{
    public class GetProductFilterCountQueryResultHandler : IRequestHandler<GetProductFilterCountQuery, Response<GetProductFilterCountQueryResult>>
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public GetProductFilterCountQueryResultHandler(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<GetProductFilterCountQueryResult>> Handle(GetProductFilterCountQuery request, CancellationToken cancellationToken)
        {
            //categoryid si 1 olanların sayısını getir.
            var values = await _repository.GetCountAsync(filter: x => x.CategoryID == 1);
            if (values > 0)
                return new Response<GetProductFilterCountQueryResult>
                {
                    ResponseStatusCode = (int)HttpStatusCode.OK,
                    ResponseData = _mapper.Map<GetProductFilterCountQueryResult>(values),
                    ResponseIsSuccessfull = true,
                    ResponseMessage = "Ürün sayısı getirildi"
                };
            return new Response<GetProductFilterCountQueryResult>
            {
                ResponseStatusCode = (int)HttpStatusCode.NotFound,
                ResponseData = null,
                ResponseIsSuccessfull = false,
                ResponseMessage = "Ürün sayısı getirilemedi"
            };
        }
    }

}
