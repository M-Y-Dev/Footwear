using AutoMapper;
using FluentValidation.Results;
using Footwear.Application.Base;
using Footwear.Application.Interfaces;
using Footwear.Application.Mediator.Commands.ContactCommands;
using Footwear.Application.Validator.CategoryValidator;
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
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, Response<object>>
    {
        private readonly IRepository<Contact> _repository;
        private readonly IMapper _mapper;

        public CreateContactCommandHandler(IRepository<Contact> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<object>> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            CreateContactCommandValidator validationRules = new CreateContactCommandValidator();

            ValidationResult validation = validationRules.Validate(request);
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
             var result = _mapper.Map<Contact>(request);
            await _repository.CreateAsync(result);
            return new Response<object>
            {
                ResponseStatusCode = (int)HttpStatusCode.Created,
                ResponseData = null,
                ResponseIsSuccessfull = true,
                ResponseMessage = "Kayıt başarıyla eklendi",
            };


        }
    }
}
