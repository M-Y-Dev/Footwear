using AutoMapper;
using FluentValidation.Results;
using Footwear.Application.Base;
using Footwear.Application.Interfaces;
using Footwear.Application.Mediator.Queries.ProductQueries;
using Footwear.Application.Mediator.Results.ProductResults;
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
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Response<GetProductByIdQueryResult>>
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<GetProductByIdQueryResult>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            GetProductByIdQueryValidator validationRules = new GetProductByIdQueryValidator();
            ValidationResult validation = validationRules.Validate(request);
            if (!validation.IsValid)
            {
                var response = new Response<GetProductByIdQueryResult>();
                foreach (var item in validation.Errors)
                {
                    response.ResponseErrors.Add(item.ErrorMessage.ToString());
                }

                response.ResponseStatusCode = 400;
                response.ResponseData = new GetProductByIdQueryResult();
                response.ResponseIsSuccessfull = false;
                response.ResponseMessage = "Kayıt getirilirken sorun yaşandı.";
                return response;
            }

            var value = await _repository.GetSingleByIdAsync(request.Id);

            if (value is null)
                return new Response<GetProductByIdQueryResult>
                {
                    ResponseStatusCode = (int)HttpStatusCode.NotFound,
                    ResponseData = null,
                    ResponseIsSuccessfull = false,
                    ResponseMessage = "Kayıt bulunamadı"
                };
            return new Response<GetProductByIdQueryResult>
            {
                ResponseStatusCode = (int)HttpStatusCode.OK,
                ResponseData = _mapper.Map<GetProductByIdQueryResult>(value),
                ResponseIsSuccessfull = true,
                ResponseMessage = "Kayıt başarıyla getirildi"
            };
        
        }
    }
}
