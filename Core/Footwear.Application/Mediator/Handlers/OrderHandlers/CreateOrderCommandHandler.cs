using AutoMapper;
using FluentValidation.Results;
using Footwear.Application.Base;
using Footwear.Application.Interfaces;
using Footwear.Application.Mediator.Commands.OrderCommands;
using Footwear.Application.Validator.AboutValidator;
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

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Response<object>>
{
    private readonly IRepository<Order> _repository;
    private readonly IMapper _mapper;

    public CreateOrderCommandHandler(IRepository<Order> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Response<object>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        CreateOrderCommandValidator validationRules = new CreateOrderCommandValidator();
        ValidationResult validationResult = validationRules.Validate(request);
        if (!validationResult.IsValid) 
        { 
            var response = new Response<object>();
            foreach (var item in validationResult.Errors)
            {
                response.ResponseErrors.Add(item.ErrorMessage.ToString());
            }
            response.ResponseStatusCode = 400;
            response.ResponseData = null;
            response.ResponseIsSuccessfull = false;
            response.ResponseMessage = "Order eklenirken bir sorun olustu!";
        }
        var result = _mapper.Map<Order>(request);
        await _repository.CreateAsync(result);

        return new Response<object>
        {
            ResponseIsSuccessfull = true,
            ResponseMessage = "Order olusturuldu",
            ResponseStatusCode = (int)HttpStatusCode.Created,
            ResponseData = null
        };
    }
}
