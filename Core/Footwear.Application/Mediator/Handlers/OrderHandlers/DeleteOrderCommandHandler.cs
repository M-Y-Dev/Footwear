using FluentValidation.Results;
using Footwear.Application.Base;
using Footwear.Application.Interfaces;
using Footwear.Application.Mediator.Commands.OrderCommands;
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

public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, Response<object>>
{
    private readonly IRepository<Order> _repository;

    public DeleteOrderCommandHandler(IRepository<Order> repository)
    {
        _repository = repository;
    }

    public async Task<Response<object>> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        DeleteOrderCommandValidator validationRules = new DeleteOrderCommandValidator();
        ValidationResult validationResult = validationRules.Validate(request);
        if (!validationResult.IsValid)
        {
            var response = new Response<object>();
            foreach (var item in validationResult.Errors)
            {
                response.ResponseErrors.Add(item.ErrorMessage.ToString());
            }
            response.ResponseStatusCode = (int)HttpStatusCode.BadRequest;
            response.ResponseData = null;
            response.ResponseIsSuccessfull = false;
            response.ResponseMessage = "An error was encountered while deleting the record!";
            return response;
        }
        var value = await _repository.GetSingleByIdAsync(request.Id);
        if (value is null)
            return new Response<object>
            {
                ResponseStatusCode = (int)HttpStatusCode.NotFound,
                ResponseData = null,
                ResponseIsSuccessfull = false,
                ResponseMessage = "No records found to delete!"
            };
        await _repository.DeleteAsync(request.Id);
        return new Response<object>
        {
            ResponseStatusCode = (int)HttpStatusCode.OK,
            ResponseData = $"Record Id: {request.Id}",
            ResponseIsSuccessfull = true,
            ResponseMessage = "Record has been deleted!"
        };
    }
}
