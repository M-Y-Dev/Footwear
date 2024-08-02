using AutoMapper;
using FluentValidation.Results;
using Footwear.Application.Base;
using Footwear.Application.Interfaces;
using Footwear.Application.Mediator.Commands.CategoryCommands;
using Footwear.Application.Validator.CategoryValidator;
using Footwear.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Response<object>>
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<object>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            UpdateCategoryCommandValidator validationRules = new UpdateCategoryCommandValidator();
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
                response.ResponseMessage = "Kayıt güncellenirken sorun yaşandı.";
                return response;
            }

            var value = await _repository.GetById(request.Id);
            if (value is null)
                return new Response<object>
                {
                    ResponseStatusCode = (int)HttpStatusCode.NotFound,
                    ResponseData = null,
                    ResponseIsSuccessfull = false,
                    ResponseMessage = "Aranılan kayıt bulunamadı"
                };

            _mapper.Map(request, value);
            await _repository.UpdateAsync(value);

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
