using AutoMapper;
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
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Response<object>>
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<object>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            UpdateProductCommandValidator validationRules = new UpdateProductCommandValidator();
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
                response.ResponseMessage = "Kayıt güncellenirken sorun yaşandı.";
                return response;
            }

            var value = await _repository.GetSingleByIdAsync(request.Id);
            if (value is null)
                return new Response<object>
                {
                    ResponseStatusCode = (int)HttpStatusCode.NotFound,
                    ResponseData = null,
                    ResponseIsSuccessfull = false,
                    ResponseMessage = "Güncellenecek kayıt bulunamadı"
                };

            _mapper.Map(request, value);
            var result = await _repository.UpdateAsync(value);

            if (result)
                return new Response<object>
                {
                    ResponseStatusCode = (int)HttpStatusCode.OK,
                    ResponseData = null,
                    ResponseIsSuccessfull = true,
                    ResponseMessage = "Kayıt güncellendi"
                };
            return new Response<object>
            {
                ResponseStatusCode = 500,
                ResponseData = null,
                ResponseIsSuccessfull = false,
                ResponseMessage = "Kayıt güncellenemedi"
            };
        }
    }
}
