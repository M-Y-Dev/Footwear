using AutoMapper;
using Footwear.Application.Base;
using Footwear.Application.Interfaces;
using Footwear.Application.Mediator.Commands.BrandCommand;
using Footwear.Application.Validator.BrandValidator;
using Footwear.Domain.Entities;
using MediatR;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Handlers.BrandHandlers
{

    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, Response<object>>
    {
        private readonly IRepository<Brand> _repository;
        private readonly IMapper _mapper;

        public CreateBrandCommandHandler ( IRepository<Brand> repository, IMapper mapper )
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<object>> Handle ( CreateBrandCommand request, CancellationToken cancellationToken )
        {
            CreateBrandCommandValidator validationRules = new CreateBrandCommandValidator();

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
            var result = _mapper.Map<Brand>(request);
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

