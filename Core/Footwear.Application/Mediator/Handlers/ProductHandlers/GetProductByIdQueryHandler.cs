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
                    response.Errors.Add(item.ErrorMessage.ToString());
                }

                response.StatusCode = 400;
                response.Data = new GetProductByIdQueryResult();
                response.IsSuccessfull = false;
                response.Message = "Kayıt getirilirken sorun yaşandı.";
                return response;
            }

            var value = await _repository.GetSingleByIdAsync(request.Id);

            if (value is null)
                return new Response<GetProductByIdQueryResult>
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Data = null,
                    IsSuccessfull = false,
                    Message = "Kayıt bulunamadı"
                };
            return new Response<GetProductByIdQueryResult>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Data = _mapper.Map<GetProductByIdQueryResult>(value),
                IsSuccessfull = true,
                Message = "Kayıt başarıyla getirildi"
            };

        }
    }
}
