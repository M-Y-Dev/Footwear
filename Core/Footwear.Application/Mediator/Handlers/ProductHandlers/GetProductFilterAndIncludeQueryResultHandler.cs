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
    public class GetProductFilterAndIncludeQueryResultHandler : IRequestHandler<GetProductFilterAndIncludeQuery, Response<List<GetProductFilterAndIncludeQueryResult>>>
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public GetProductFilterAndIncludeQueryResultHandler(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<List<GetProductFilterAndIncludeQueryResult>>> Handle(GetProductFilterAndIncludeQuery request, CancellationToken cancellationToken)
        {
            //categori idsi 1 olanları category include ederek listele
            var values = await _repository.GetAllAsync(filter: x => x.CategoryID == 1, includes: x => x.Category);
            if (values.Any())
                return new Response<List<GetProductFilterAndIncludeQueryResult>>
                {
                    ResponseIsSuccessfull = true,
                    ResponseData = _mapper.Map<List<GetProductFilterAndIncludeQueryResult>>(values),
                    ResponseMessage = "Kayıtlar başarıyla getirildi",
                    ResponseStatusCode = (int)HttpStatusCode.OK,
                };
            return new Response<List<GetProductFilterAndIncludeQueryResult>>
            {
                ResponseIsSuccessfull = false,
                ResponseData = _mapper.Map<List<GetProductFilterAndIncludeQueryResult>>(values),
                ResponseMessage = "Listelenecek kayıt bulunamadı",
                ResponseStatusCode = (int)HttpStatusCode.NotFound,
            };
        }
    }

}
