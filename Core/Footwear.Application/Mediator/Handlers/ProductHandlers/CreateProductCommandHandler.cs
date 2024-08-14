using AutoMapper;
using FluentValidation.Results;
using Footwear.Application.Base;
using Footwear.Application.Interfaces;
using Footwear.Application.Mediator.Commands.ProductCommands;
using Footwear.Application.Validator.ProductValidator;
using Footwear.Domain.Entities;
using MediatR;
using System.Net;


namespace Footwear.Application.Mediator.Handlers.ProductHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Response<object>>
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;


        public CreateProductCommandHandler(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<Response<object>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            CreateProductCommandValidator validationRules = new CreateProductCommandValidator();
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

            var mapped = _mapper.Map<Product>(request);
            var result = await _repository.CreateAsync(mapped);

            if (result) // result==true anlamındadır ve sonuç başarılıdır
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

