using AutoMapper;
using FluentValidation.Results;
using Footwear.Application.Base;
using Footwear.Application.Interfaces;
using Footwear.Application.Mediator.Queries.RoleQueries;
using Footwear.Application.Mediator.Results.RoleResults;
using Footwear.Application.Mediator.Results.SocialMediaResults;
using Footwear.Application.Validator.RoleValidator;
using Footwear.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Handlers.RoleHandlers
{
    public class GetRoleByIdQueryResultHandler : IRequestHandler<GetRoleByIdQuery, Response<GetRoleByIdQueryResult>>
    {
        private readonly IRepository<AppRole> _roleRepository;
        private readonly IMapper _mapper;

        public GetRoleByIdQueryResultHandler(IRepository<AppRole> roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<Response<GetRoleByIdQueryResult>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            GetRoleByIdQueryValidator validationRules = new GetRoleByIdQueryValidator();
            ValidationResult validation=validationRules.Validate(request);
            if (!validation.IsValid)
            {
                var response = new Response<GetRoleByIdQueryResult>();
                foreach(var item in validation.Errors)
                {
                    response.ResponseErrors.Add(item.ErrorMessage.ToString());
                }
                response.ResponseStatusCode = 400;
                response.ResponseData = new GetRoleByIdQueryResult();
                response.ResponseIsSuccessfull = false;
                response.ResponseMessage = "Kayıt getirilirken sorun yaşandı.";
                return response;
            }
            var value = await _roleRepository.GetSingleByIdAsync(request.RoleId);
            if(value is null)
            {
                return new Response<GetRoleByIdQueryResult>
                {
                    ResponseStatusCode = (int)HttpStatusCode.NotFound,
                    ResponseData = null,
                    ResponseIsSuccessfull = false,
                    ResponseMessage = "Kayıt bulunamadı"
                };
            }
            else
            {
                return new Response<GetRoleByIdQueryResult>
                {
                    ResponseStatusCode = (int)HttpStatusCode.OK,
                    ResponseData = _mapper.Map<GetRoleByIdQueryResult>(value),
                    ResponseIsSuccessfull = true,
                    ResponseMessage = "Kayıt başarıyla getirildi"
                };
            }
        }
    }
}
