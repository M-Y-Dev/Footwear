using AutoMapper;
using Footwear.Application.Base;
using Footwear.Application.Interfaces;
using Footwear.Application.Mediator.Queries.OrderQueries;
using Footwear.Application.Mediator.Results.AboutResults;
using Footwear.Application.Mediator.Results.OrderResults;
using Footwear.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Handlers.OrderHandlers;

public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, Response<List<GetOrderQueryResult>>>
{
    private readonly IRepository<Order> _repository;
    private readonly IMapper _mapper;

    public GetOrderQueryHandler(IRepository<Order> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Response<List<GetOrderQueryResult>>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
      var values = await _repository.GetAllAsync();
        if (values.Any())
            return new Response<List<GetOrderQueryResult>>
            {
                ResponseIsSuccessfull = true,
                ResponseData = _mapper.Map<List<GetOrderQueryResult>>(values),
                ResponseMessage = "Kayıtlar başarıyla getirildi",
                ResponseStatusCode = (int)HttpStatusCode.OK
            };
        return new Response<List<GetOrderQueryResult>>
        {
            ResponseIsSuccessfull = false,
            ResponseData = _mapper.Map<List<GetOrderQueryResult>>(values),
            ResponseMessage = "Listelenecek kayıt bulunamadı",
            ResponseStatusCode = (int)HttpStatusCode.NotFound,
        };
    }
}
