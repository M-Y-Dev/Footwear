using AutoMapper;
using FluentValidation.Results;
using Footwear.Application.Base;
using Footwear.Application.Interfaces;
using Footwear.Application.Mediator.Commands.BasketCommands;
using Footwear.Application.Mediator.Commands.BasketCommands;
using Footwear.Application.Validator.BasketValidator;
using Footwear.Application.Validator.BasketValidator;
using Footwear.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Handlers.BasketHandlers
{
    public class CreateBasketCommandHandler : IRequestHandler<CreateBasketCommand, Response<object>>
    {
        private readonly IRepository<Basket> _repository;
        private readonly IMapper _mapper;

        public CreateBasketCommandHandler(IRepository<Basket> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<object>> Handle(CreateBasketCommand request, CancellationToken cancellationToken)
        {
            CreateBasketCommandValidator validationRules = new CreateBasketCommandValidator();
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

            var mapped = _mapper.Map<Basket>(request);
            var result = await _repository.CreateAsync(mapped);

            if (result) 
                return new Response<object>
                {
                    ResponseStatusCode = (int)HttpStatusCode.Created,
                    ResponseData = null,
                    ResponseIsSuccessfull = true,
                    ResponseMessage = "Kayıt başarıyla eklendi",
                };

            return new Response<object>
            {
                ResponseStatusCode = 500,
                ResponseData = null,
                ResponseIsSuccessfull = false,
                ResponseMessage = "Kayıt eklenemedi",
            };
        }
    }
}
