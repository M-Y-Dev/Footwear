using AutoMapper;
using FluentValidation.Results;
using Footwear.Application.Base;
using Footwear.Application.Interfaces;
using Footwear.Application.Mediator.Queries.AddressQueries;
using Footwear.Application.Mediator.Results.AddressResults;
using Footwear.Application.Validator.AddressValidator;
using Footwear.Application.Validator.ContactValidator;
using Footwear.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Handlers.AddressHandlers
{
    public class GetAddressByIdQueryHandler: IRequestHandler<GetAddressByIdQuery, Response<GetAddressByIdQueryResult>>
    {
        private readonly IRepository<Address> _repository;
        private readonly IMapper _mapper;

        public GetAddressByIdQueryHandler(IRepository<Address> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<GetAddressByIdQueryResult>> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
        {
            GetAddressByIdQueryValidator validationRules = new GetAddressByIdQueryValidator();
            ValidationResult validation = validationRules.Validate(request);
            
            if(!validation.IsValid)
            {
                var response = new Response<GetAddressByIdQueryResult>();
                foreach (var item in validation.Errors)
                {
                    response.ResponseErrors.Add(item.ErrorMessage.ToString());
                }

                response.ResponseStatusCode = 400;
                response.ResponseData = new GetAddressByIdQueryResult();
                response.ResponseIsSuccessfull = false;
                response.ResponseMessage = "Kayıt getirilirken sorun yaşandı.";
                return response;
            }
            var value = await _repository.GetSingleByIdAsync(request.Id);
            if(value is null)
            {
                return new Response<GetAddressByIdQueryResult>
                {
                    ResponseStatusCode = (int)HttpStatusCode.NotFound,
                    ResponseData = null,
                    ResponseIsSuccessfull = false,
                    ResponseMessage = "Kayıt bulunamadı"
                };
            }
            return new Response<GetAddressByIdQueryResult>
            {
                ResponseStatusCode = (int)HttpStatusCode.OK,
                ResponseData = _mapper.Map<GetAddressByIdQueryResult>(value),
                ResponseIsSuccessfull = true,
                ResponseMessage = "Kayıt başarıyla getirildi"
            };
        }
    }
}
