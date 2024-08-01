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
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response<object>>
    {
        private readonly IRepository<AppUser> _userRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IRepository<AppUser> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Response<object>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            CreateUserCommandValidator validationRules = new CreateUserCommandValidator();
            ValidationResult validation = validationRules.Validate(request);
            if (!validation.IsValid)
            {
                var response = new Response<object>();
                foreach(var item in validation.Errors)
                {
                    response.ResponseErrors.Add(validation.Errors.ToString());
                }
                response.ResponseStatusCode = 400;
                response.ResponseData = null;
                response.ResponseIsSuccessfull = false;
                response.ResponseMessage = "Kayıt eklenirken sorun yaşandı.";
                return response;
            }
            else
            {
                var result = _mapper.Map<AppUser>(request);
                await _userRepository.CreateAsync(result);
                return new Response<object>
                {
                    ResponseStatusCode = (int)HttpStatusCode.Created,
                    ResponseData = null,
                    ResponseIsSuccessfull = true,
                    ResponseMessage = "Kullanıcı Ekleme İşlemi Başarı İle Gerçekleştirildi.",
                };
            }
        }
    }
}
