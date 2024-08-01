using FluentValidation.Results;
using Footwear.Application.Base;
using Footwear.Application.Interfaces;
using Footwear.Application.Mediator.Commands.RoleCommands;
using Footwear.Application.Validator.RoleValidator;
using Footwear.Domain.Entities;
using MediatR;
using System.Net;

namespace Footwear.Application.Application.Mediator.Handlers.RoleHandlers
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, Response<object>>
    {
        private readonly IRepository<AppRole> _roleRepository;

        public DeleteRoleCommandHandler(IRepository<AppRole> roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<Response<object>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            DeleteRoleCommandValidator validationRules = new DeleteRoleCommandValidator();
            ValidationResult validation=validationRules.Validate(request);
            if(!validation.IsValid)
            {
                var response = new Response<object>();
                foreach(var item in validation.Errors)
                {
                    response.ResponseErrors.Add(item.ErrorMessage.ToString());
                }
                response.ResponseStatusCode = 400;
                response.ResponseData = null;
                response.ResponseIsSuccessfull = false;
                response.ResponseMessage = "Rol Silme Esnasında Bir Hata Meydana Geldi";
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
                    ResponseMessage = "Silinecek kayıt bulunamadı"
                };
            }
            else
            {
                await _roleRepository.DeleteAsync(request.RoleId);
                return new Response<object>
                {
                    ResponseStatusCode = (int)HttpStatusCode.OK,
                    ResponseData = "Kayıt silindi",
                    ResponseIsSuccessfull = true,
                    ResponseMessage = null
                };
            }
        }
    }
}
