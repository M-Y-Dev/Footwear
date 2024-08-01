using AutoMapper;
using FluentValidation.Results;
using Footwear.Application.Base;
using Footwear.Application.Interfaces;
using Footwear.Application.Mediator.Queries.UserQueries;
using Footwear.Application.Mediator.Results.RoleResults;
using Footwear.Application.Mediator.Results.UserResults;
using Footwear.Application.Validator.UserValidator;
using Footwear.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Handlers.UserHandlers
{
    public class GetUserByIdQueryResultHandler : IRequestHandler<GetUserByIdQuery, Response<GetUserByIdQueryResult>>
    {
        private readonly IRepository<AppUser> _userRepository;
        private readonly IMapper _mapper;

        public GetUserByIdQueryResultHandler(IRepository<AppUser> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Response<GetUserByIdQueryResult>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            GetUserByIdQueryValidator validationRules = new GetUserByIdQueryValidator();
            ValidationResult validation = validationRules.Validate(request);
            if (!validation.IsValid)
            {
                var response = new Response<GetUserByIdQueryResult>();
                foreach (var item in validation.Errors)
                {
                    response.ResponseErrors.Add(item.ErrorMessage.ToString());
                }
                response.ResponseStatusCode = 400;
                response.ResponseData = new GetUserByIdQueryResult();
                response.ResponseIsSuccessfull = false;
                response.ResponseMessage = "Kayıt getirilirken sorun yaşandı.";
                return response;
            }
            var value = await _userRepository.GetById(request.UserId);
            if(value is null)
            {
                return new Response<GetUserByIdQueryResult>
                {
                    ResponseStatusCode = (int)HttpStatusCode.NotFound,
                    ResponseData = null,
                    ResponseIsSuccessfull = false,
                    ResponseMessage = "Kayıt bulunamadı"
                };
            }
            else
            {
                return new Response<GetUserByIdQueryResult>
                {
                    ResponseStatusCode = (int)HttpStatusCode.OK,
                    ResponseData = _mapper.Map<GetUserByIdQueryResult>(value),
                    ResponseIsSuccessfull = true,
                    ResponseMessage = "Kayıt başarıyla getirildi"
                };
            }
        }
    }
}
