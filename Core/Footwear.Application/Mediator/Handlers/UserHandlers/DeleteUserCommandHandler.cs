using AutoMapper;
using FluentValidation.Results;
using Footwear.Application.Base;
using Footwear.Application.Interfaces;
using Footwear.Application.Mediator.Commands.UserCommands;
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
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Response<object>>
    {
        private readonly IRepository<AppUser> _userRepository;
        private readonly IMapper _mapper;

        public DeleteUserCommandHandler(IRepository<AppUser> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Response<object>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            DeleteUserCommandValidator validationRules = new DeleteUserCommandValidator();
            ValidationResult validation=validationRules.Validate(request);
            if (!validation.IsValid)
            {
                var response = new Response<object>();
                foreach (var item in validation.Errors)
                {
                    response.ResponseErrors.Add(item.ErrorMessage.ToString());
                }
                response.ResponseStatusCode = 400;
                response.ResponseData = null;
                response.ResponseIsSuccessfull = false;
                response.ResponseMessage = "Kullanıcı kaydını silerken Bir Hata Meydana Geldi";
                return response;
            }
            var value = await _userRepository.GetSingleByIdAsync(request.Id);
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
                await _userRepository.DeleteAsync(request.Id);
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
