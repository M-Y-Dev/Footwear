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
    public class GetProductWithCategoryQueryResultHandler : IRequestHandler<GetProductWithCategoryQuery, List<GetProductWithCategoryQueryResult>>
    {
        private readonly IProductRespository _repository;
        private readonly IMapper _mapper;

        public GetProductWithCategoryQueryResultHandler(IProductRespository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //public async Task<Response<List<GetProductWithCategoryQueryResult>>> Handle(GetProductWithCategoryQuery request, CancellationToken cancellationToken)
        //{
        //    var values = await _repository.GetProductListWithCategory();
        //    var list = values.Select(x => new GetProductWithCategoryQueryResult
        //    {
        //        CategoryID = x.CategoryID,
        //        CategoryName = x.Category.CategoryName,
        //        Price = x.Price,
        //        ProductImageUrl = x.ProductImageUrl,
        //        ProductName = x.ProductName,
        //        ProductStock = x.ProductStock,
        //        Id = x.Id
                
        //    }).ToList();

        //    if (list.Any())
        //        return new Response<List<GetProductWithCategoryQueryResult>>
        //        {
        //            ResponseIsSuccessfull = true,
        //            ResponseData = _mapper.Map<List<GetProductWithCategoryQueryResult>>(list),
        //            ResponseMessage = "Kayıtlar başarıyla getirildi",
        //            ResponseStatusCode = (int)HttpStatusCode.OK,
        //        };
        //    return new Response<List<GetProductWithCategoryQueryResult>>
        //    {
        //        ResponseIsSuccessfull = false,
        //        ResponseData = _mapper.Map<List<GetProductWithCategoryQueryResult>>(list),
        //        ResponseMessage = "Listelenecek kayıt bulunamadı",
        //        ResponseStatusCode = (int)HttpStatusCode.NotFound,
        //    };
        //}

        public async Task<List<GetProductWithCategoryQueryResult>> Handle(GetProductWithCategoryQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetProductListWithCategory();
            var list = values.Select(x => new GetProductWithCategoryQueryResult
            {
                CategoryID = x.CategoryID,
                CategoryName = x.Category.CategoryName,
                Price = x.Price,
                ProductImageUrl = x.ProductImageUrl,
                ProductName = x.ProductName,
                ProductStock = x.ProductStock,
                Id = x.Id

            }).ToList();

            return list;
            
        }
    }
}