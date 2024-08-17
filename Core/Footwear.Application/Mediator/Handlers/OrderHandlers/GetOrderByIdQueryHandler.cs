using AutoMapper;
using FluentValidation.Results;
using Footwear.Application.Base;
using Footwear.Application.Interfaces;
using Footwear.Application.Mediator.Queries.OrderQueries;
using Footwear.Application.Mediator.Results.OrderResults;
using Footwear.Application.Validator.OrderValidator;
using Footwear.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Handlers.OrderHandlers;

public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Response<GetOrderByIdQueryResult>>
{
    private readonly IRepository<Order> _repository;
    private readonly IMapper _mapper;

    public GetOrderByIdQueryHandler(IMapper mapper, IRepository<Order> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Response<GetOrderByIdQueryResult>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        GetOrderByIdQueryValidator validationRules = new GetOrderByIdQueryValidator();
        ValidationResult validationResult = validationRules.Validate(request);
        if (!validationResult.IsValid) 
        { 
            var response = new Response<GetOrderByIdQueryResult>();
            foreach (var item in validationResult.Errors)
            {
                response.ResponseErrors.Add(item.ErrorMessage.ToString());
            }
            response.ResponseStatusCode = (int)HttpStatusCode.BadRequest;
            response.ResponseData = new GetOrderByIdQueryResult();
            response.ResponseIsSuccessfull = false;
            response.ResponseMessage = "An error was encountered while listening the record!";
            return response;
        }
       var values = await _repository.GetSingleByIdAsync(request.Id);

        if (values is null)
            return new Response<GetOrderByIdQueryResult>
            {
                ResponseStatusCode = (int)HttpStatusCode.NotFound,
                ResponseData = null,
                ResponseIsSuccessfull = false,
                ResponseMessage = "No records found to delete!"
            };
        return new Response<GetOrderByIdQueryResult>
        {
            ResponseStatusCode = (int)HttpStatusCode.OK,
            ResponseIsSuccessfull = true,
            ResponseErrors = null,
            ResponseMessage = "Record has been listed!",
            ResponseData = _mapper.Map<GetOrderByIdQueryResult>(values)            
        };        
    }
}
