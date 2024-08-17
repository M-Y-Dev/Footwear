using AutoMapper;
using FluentValidation.Results;
using Footwear.Application.Base;
using Footwear.Application.Interfaces;
using Footwear.Application.Mediator.Commands.OrderCommands;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace Footwear.Application.Mediator.Handlers.OrderHandlers;

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Response<object>>
{
    private readonly IRepository<Order> _repository;
    private readonly IMapper _mapper;

    public UpdateOrderCommandHandler(IRepository<Order> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Response<object>> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        UpdateOrderCommandValidator validationRules = new UpdateOrderCommandValidator();
        ValidationResult validationResult = validationRules.Validate(request);
        if (!validationResult.IsValid)
        {
            var response = new Response<object>();
            foreach (var item in validationResult.Errors)
            {
                response.ResponseErrors.Add(item.ErrorMessage.ToString());
            }

            response.ResponseStatusCode = (int)HttpStatusCode.BadRequest;
            response.ResponseData = new UpdateOrderCommand();
            response.ResponseIsSuccessfull = false;
            response.ResponseMessage = "An error was encountered while updating the record!";
            return response;
        }
        var values = await _repository.GetSingleByIdAsync(request.Id);
        if (values is null)
            return new Response<object>
            {
                ResponseStatusCode = (int)HttpStatusCode.NotFound,
                ResponseData = false,
                ResponseIsSuccessfull = false,
                ResponseMessage = "No records found to update!"
            };
        _mapper.Map(request, values);
        var data = await _repository.UpdateAsync(values);

        return new Response<object>
        {
            ResponseStatusCode = (int)HttpStatusCode.OK,
            ResponseIsSuccessfull = true,
            ResponseErrors = null,
            ResponseMessage = "Record has been updated!",
            ResponseData = data
        };
    }
}
