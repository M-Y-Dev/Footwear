using AutoMapper;
using FluentValidation.Results;
using Footwear.Application.Base;
using Footwear.Application.Interfaces;
using Footwear.Application.Mediator.Commands.RoleCommands;
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
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, Response<object>>
    {
        private readonly IRepository<AppRole> _roleRepository;
        private readonly IMapper _mapper;

        public UpdateRoleCommandHandler(IRepository<AppRole> roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<Response<object>> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            UpdateRoleCommandValidator validationRules= new UpdateRoleCommandValidator();   
            ValidationResult validation=validationRules.Validate(request);
            if (!validation.IsValid)
            {
                var response = new Response<object>();
                foreach(var item in validation.Errors)
                {
                    response.ResponseErrors.Add(item.ErrorMessage.ToString());
                }
                response.ResponseStatusCode = 400;
                response.ResponseData = null;
                response.ResponseIsSuccessfull = false;
                response.ResponseMessage = "Kayıt Güncelleme esnasında bir hata meydana geldi";
                return response;
            }

            var value = await _roleRepository.GetById(request.RoleId);
            if(value is null)
            {
                return new Response<object>
                {
                    ResponseStatusCode = (int)HttpStatusCode.NotFound,
                    ResponseData = null,
                    ResponseIsSuccessfull = false,
                    ResponseMessage = "Aranılan kayıt bulunamadı"
                };
            }
            else
            {
                _mapper.Map(request,value);
                await _roleRepository.UpdateAsync(value);
                return new Response<object>
                {
                    ResponseStatusCode = (int)HttpStatusCode.OK,
                    ResponseData = null,
                    ResponseIsSuccessfull = true,
                    ResponseMessage = "Kayıt güncellendi"
                };
            }
        }
    }
}
