﻿using FluentValidation.Results;
using Footwear.Application.Base;
using Footwear.Application.Interfaces;
using Footwear.Application.Mediator.Commands.BasketCommands;
using Footwear.Application.Validator.BasketValidator;
using Footwear.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Handlers.BasketHandlers
{
    public class DeleteBasketCommandHandler : IRequestHandler<DeleteBasketCommand, Response<object>>
    {
        private readonly IRepository<Basket> _repository;

        public DeleteBasketCommandHandler(IRepository<Basket> repository)
        {
            _repository = repository;
        }

        public async Task<Response<object>> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
        {
            DeleteBasketCommandValidator validationRules = new DeleteBasketCommandValidator();
            ValidationResult validation = validationRules.Validate(request);
            if (!validation.IsValid)
            {
                var response = new Response<object>();
                foreach (var item in validation.Errors)
                {
                    response.ResponseErrors.Add(item.ErrorMessage.ToString());
                }

                response.ResponseStatusCode = 400;
                response.ResponseData = null;
                response.ResponseIsSuccessfull = false;
                response.ResponseMessage = "Kayıt silinirken sorun yaşandı.";
                return response;
            }

            var value = await _repository.GetSingleByIdAsync(request.Id);

            if (value is null)
                return new Response<object>
                {
                    ResponseStatusCode = (int)HttpStatusCode.NotFound,
                    ResponseData = null,
                    ResponseIsSuccessfull = false,
                    ResponseMessage = "Silinecek kayıt bulunamadı"
                };
            await _repository.DeleteAsync(request.Id);
            return new Response<object>
            {
                ResponseStatusCode = (int)HttpStatusCode.OK,
                ResponseData = null,
                ResponseIsSuccessfull = true,
                ResponseMessage = "Kayıt silindi",
            };
        }
    }
}
