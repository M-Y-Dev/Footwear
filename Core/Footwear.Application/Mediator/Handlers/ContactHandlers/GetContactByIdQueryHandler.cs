using AutoMapper;
using FluentValidation.Results;
using Footwear.Application.Base;
using Footwear.Application.Interfaces;
using Footwear.Application.Mediator.Queries.ContactQueries;
using Footwear.Application.Mediator.Results.ContactResults;
using Footwear.Application.Validator.ContactValidator;
using Footwear.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Handlers.ContactHandlers
{
    public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, Response<GetContactByIdQueryResult>>
    {
        private readonly IRepository<Contact> _repository;
        private readonly IMapper _mapper;

        public GetContactByIdQueryHandler(IRepository<Contact> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<Response<GetContactByIdQueryResult>> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            GetContactByIdQueryValidator validationRules = new GetContactByIdQueryValidator();
            ValidationResult validation = validationRules.Validate(request);
            if (!validation.IsValid)
            {
                var response = new Response<GetContactByIdQueryResult>();
                foreach (var item in validation.Errors)
                {
                    response.ResponseErrors.Add(item.ErrorMessage.ToString());
                }

                response.ResponseStatusCode = 400;
                response.ResponseData = new GetContactByIdQueryResult();
                response.ResponseIsSuccessfull = false;
                response.ResponseMessage = "Kayıt getirilirken sorun yaşandı.";
                return response;
            }

            var value = await _repository.GetSingleByIdAsync(request.Id);
            if (value is null)
            {
                return new Response<GetContactByIdQueryResult>
                {
                    ResponseStatusCode = (int)HttpStatusCode.NotFound,
                    ResponseData = null,
                    ResponseIsSuccessfull = false,
                    ResponseMessage = "Kayıt bulunamadı"
                };
            }

            return new Response<GetContactByIdQueryResult>
            {
                ResponseStatusCode = (int)HttpStatusCode.OK,
                ResponseData = _mapper.Map<GetContactByIdQueryResult>(value),
                ResponseIsSuccessfull = true,
                ResponseMessage = "Kayıt başarıyla getirildi"
            };

        }
    }
}

