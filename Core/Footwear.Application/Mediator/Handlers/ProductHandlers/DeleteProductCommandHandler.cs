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
                    response.Errors.Add(item.ErrorMessage.ToString());
                }

                response.StatusCode = 400;
                response.Data = null;
                response.IsSuccessfull = false;
                response.Message = "Kayıt silinirken sorun yaşandı.";
                return response;
            }

            var value = await _repository.GetSingleByIdAsync(request.Id);

            if (value is null)
                return new Response<object>
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Data = null,
                    IsSuccessfull = false,
                    Message = "Silinecek kayıt bulunamadı"
                };

            var result = await _repository.DeleteAsync(request.Id);

            if (result) // result==true anlamındadır ve sonuç başarılıdır
                return new Response<object>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Data = null,
                    IsSuccessfull = true,
                    Message = "Kayıt Silindi",
                };
            return new Response<object>
            {
                StatusCode = 500,
                Data = null,
                IsSuccessfull = false,
                Message = "Kayıt silinemedi",
            };

        }
    }
}
