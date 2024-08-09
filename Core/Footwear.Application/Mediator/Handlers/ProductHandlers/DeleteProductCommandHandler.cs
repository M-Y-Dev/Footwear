using FluentValidation.Results;
using Footwear.Application.Base;
using Footwear.Application.Interfaces;
using Footwear.Application.Mediator.Commands.ProductCommands;
using Footwear.Application.Validator.ProductValidator;
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
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Response<object>>
    {
        private readonly IRepository<Product> _repository;

        public DeleteProductCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<Response<object>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            DeleteProductCommandValidator validationRules = new DeleteProductCommandValidator();
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

            if ( value is null)
                return new Response<object>
                {
                    ResponseStatusCode = (int)HttpStatusCode.NotFound,
                    ResponseData = null,
                    ResponseIsSuccessfull = false,
                    ResponseMessage = "Silinecek kayıt bulunamadı"
                };

            var result = await _repository.DeleteAsync(request.Id);

            if(result)
                return new Response<object>
                {
                    ResponseStatusCode = (int)HttpStatusCode.OK,
                    ResponseData = null,
                    ResponseIsSuccessfull = true,
                    ResponseMessage = "Kayıt silindi",
                };
            return new Response<object>
            {
                ResponseStatusCode = 500,
                ResponseData = null,
                ResponseIsSuccessfull = false,
                ResponseMessage = "Kayıt silinemedi",
            };


        }
    }
}
