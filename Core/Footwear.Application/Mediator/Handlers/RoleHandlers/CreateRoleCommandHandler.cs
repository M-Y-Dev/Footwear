using AutoMapper;
using FluentValidation.Results;
using Footwear.Application.Base;
using Footwear.Application.Interfaces;
using Footwear.Application.Mediator.Commands.RoleCommands;
using Footwear.Application.Validator.RoleValidator;
using Footwear.Domain.Entities;
using MediatR;
using System.Net;

namespace Footwear.Application.Mediator.Handlers.RoleHandlers
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, Response<object>>
    {
        private readonly IRepository<AppRole> _roleRepository;
        private readonly IMapper _mapper;

        public CreateRoleCommandHandler(IRepository<AppRole> roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<Response<object>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            CreateRoleCommandValidator validationRules = new CreateRoleCommandValidator();
            ValidationResult validation= validationRules.Validate(request);
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
                response.ResponseMessage = "Kayıt eklenirken sorun yaşandı.";
                return response;
            }
            var result = _mapper.Map<AppRole>(request);
            await _roleRepository.CreateAsync(result);

            return new Response<object>
            {
                ResponseStatusCode = (int)HttpStatusCode.Created,
                ResponseData = null,
                ResponseIsSuccessfull = true,
                ResponseMessage = "Rol Ekleme İşlemi Başarı İle Gerçekleştirildi.",
            };
        }
    }
}
