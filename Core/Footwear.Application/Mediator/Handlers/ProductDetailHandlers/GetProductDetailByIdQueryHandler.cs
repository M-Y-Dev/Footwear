using AutoMapper;
using FluentValidation.Results;
using Footwear.Application.Base;
using Footwear.Application.Interfaces;
using Footwear.Application.Mediator.Queries.ProductDetailQueries;
using Footwear.Application.Mediator.Results.ProductDetailsResults;
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
    public class GetProductDetailByIdQueryHandler : IRequestHandler<GetProductDetailByIdQuery, Response<GetProductDetailByIdQueryResult>>
    {
        private readonly IRepository<ProductDetail> _repository;
        private readonly IMapper _mapper;

        public GetProductDetailByIdQueryHandler(IRepository<ProductDetail> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<GetProductDetailByIdQueryResult>> Handle(GetProductDetailByIdQuery request, CancellationToken cancellationToken)
        {
            GetProductDetailByIdQueryValidator validationRules = new GetProductDetailByIdQueryValidator();
            ValidationResult validation = validationRules.Validate(request);
            if (!validation.IsValid)
            {
                var response = new Response<GetProductDetailByIdQueryResult>();
                foreach (var item in validation.Errors)
                {
                    response.ResponseErrors.Add(item.ErrorMessage.ToString());
                }

                response.ResponseStatusCode = 400;
                response.ResponseData = new GetProductDetailByIdQueryResult();
                response.ResponseIsSuccessfull = false;
                response.ResponseMessage = "Kayıt getirilirken sorun yaşandı.";
                return response;
            }

            var value = await _repository.GetSingleByIdAsync(request.Id);

            if (value is null)
                return new Response<GetProductDetailByIdQueryResult>
                {
                    ResponseStatusCode = (int)HttpStatusCode.NotFound,
                    ResponseData = null,
                    ResponseIsSuccessfull = false,
                    ResponseMessage = "Kayıt bulunamadı"
                };
            return new Response<GetProductDetailByIdQueryResult>
            {
                ResponseStatusCode = (int)HttpStatusCode.OK,
                ResponseData = _mapper.Map<GetProductDetailByIdQueryResult>(value),
                ResponseIsSuccessfull = true,
                ResponseMessage = "Kayıt başarıyla getirildi"
            };

        }
    }
}