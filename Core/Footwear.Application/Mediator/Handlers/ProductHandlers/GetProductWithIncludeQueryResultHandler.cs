﻿using AutoMapper;
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
    
     public class GetProductWithIncludeQueryResultHandler : IRequestHandler<GetProductWithCategoryIncludeQuery, Response<List<GetProductWithCategoryIncludeQueryResult>>>
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public GetProductWithIncludeQueryResultHandler(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<List<GetProductWithCategoryIncludeQueryResult>>> Handle(GetProductWithCategoryIncludeQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync(filter: null, includes: x => x.Category);
            if (values.Any())
                return new Response<List<GetProductWithCategoryIncludeQueryResult>>
                {
                    ResponseIsSuccessfull = true,
                    ResponseData = _mapper.Map<List<GetProductWithCategoryIncludeQueryResult>>(values),
                    ResponseMessage = "Kayıtlar başarıyla getirildi",
                    ResponseStatusCode = (int)HttpStatusCode.OK,
                };
            return new Response<List<GetProductWithCategoryIncludeQueryResult>>
            {
                ResponseIsSuccessfull = false,
                ResponseData = _mapper.Map<List<GetProductWithCategoryIncludeQueryResult>>(values),
                ResponseMessage = "Listelenecek kayıt bulunamadı",
                ResponseStatusCode = (int)HttpStatusCode.NotFound,
            };
        }
    }
}