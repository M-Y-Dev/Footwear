using AutoMapper;
using FluentValidation.Results;
using Footwear.Application.Base;
using Footwear.Application.Interfaces;
using Footwear.Application.Mediator.Queries.AboutQueries;
using Footwear.Application.Mediator.Results.AboutResults;
using Footwear.Application.Validator.AboutValidator;
using Footwear.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Handlers.AboutHandlers
{
    public class GetAboutByIdQueryHandler : IRequestHandler<GetAboutByIdQuery, Response<GetAboutByIdQueryResult>>
    {
        private readonly IRepository<About> _repository;
        private readonly IMapper _mapper;

        public GetAboutByIdQueryHandler(IRepository<About> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<GetAboutByIdQueryResult>> Handle(GetAboutByIdQuery request, CancellationToken cancellationToken)
        {
            GetAboutByIdQueryValidator validationRules = new GetAboutByIdQueryValidator();
            ValidationResult validation = validationRules.Validate(request);
            if (!validation.IsValid)
            {
                var response = new Response<GetAboutByIdQueryResult>();
                foreach (var item in validation.Errors)
                {
                    response.ResponseErrors.Add(item.ErrorMessage.ToString());
                }

                response.ResponseStatusCode = 400;
                response.ResponseData = new GetAboutByIdQueryResult();
                response.ResponseIsSuccessfull = false;
                response.ResponseMessage = "Kayıt getirilirken sorun yaşandı.";
                return response;
            }
            var value = await _repository.GetSingleByIdAsync(request.Id);

            if (value is null)
                return new Response<GetAboutByIdQueryResult>
                {
                    ResponseStatusCode = (int)HttpStatusCode.NotFound,
                    ResponseData = null,
                    ResponseIsSuccessfull = false,
                    ResponseMessage = "Kayıt bulunamadı"
                };
            return new Response<GetAboutByIdQueryResult>
            {
                ResponseStatusCode = (int)HttpStatusCode.OK,
                ResponseData = _mapper.Map<GetAboutByIdQueryResult>(value),
                ResponseIsSuccessfull = true,
                ResponseMessage = "Kayıt başarıyla getirildi"
            };
        }
    }
}
