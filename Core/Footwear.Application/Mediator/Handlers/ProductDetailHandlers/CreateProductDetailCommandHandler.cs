using AutoMapper;
using FluentValidation.Results;
using Footwear.Application.Base;
using Footwear.Application.Interfaces;
using Footwear.Application.Mediator.Commands.ProductDetails;
using Footwear.Application.Validator.ProductDetailValidator;
using Footwear.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Handlers.ProductDetailHandlers
{
    public class CreateProductDetailCommandHandler : IRequestHandler<CreateProductDetailCommand, Response<object>>
    {
        private readonly IRepository<ProductDetail> _repository;
        private readonly IMapper _mapper;

        public CreateProductDetailCommandHandler(IRepository<ProductDetail> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<object>> Handle(CreateProductDetailCommand request, CancellationToken cancellationToken)
        {
            CreateProductDeatilCommandValidator validationRules = new CreateProductDeatilCommandValidator();
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
                response.ResponseMessage = "Kayıt eklenirken sorun yaşandı.";
                return response;
            }

            var result = _mapper.Map<ProductDetail>(request);
            await _repository.CreateAsync(result);

            return new Response<object>
            {
                ResponseStatusCode = (int)HttpStatusCode.Created,
                ResponseData = null,
                ResponseIsSuccessfull = true,
                ResponseMessage = "Kayıt başarıyla eklendi",
            };
        }
    }
}
