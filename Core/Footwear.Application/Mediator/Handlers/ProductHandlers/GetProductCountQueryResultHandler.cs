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
    public class GetProductCountQueryResultHandler : IRequestHandler<GetProductCountQuery, Response<GetProductCountQueryResult>>
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public GetProductCountQueryResultHandler(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<GetProductCountQueryResult>> Handle(GetProductCountQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetCountAsync();
            if (values > 0)
                return new Response<GetProductCountQueryResult>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Data = _mapper.Map<GetProductCountQueryResult>(values),
                    IsSuccessfull = true,
                    Message = "Ürün sayısı getirildi"
                };
            return new Response<GetProductCountQueryResult>
            {
                StatusCode = (int)HttpStatusCode.NotFound,
                Data = null,
                IsSuccessfull = false,
                Message = "Ürün sayısı getirilemedi"
            };
        }
    }

}
