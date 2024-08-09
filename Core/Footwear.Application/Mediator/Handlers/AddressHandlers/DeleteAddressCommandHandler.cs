using FluentValidation.Results;
using Footwear.Application.Base;
using Footwear.Application.Interfaces;
using Footwear.Application.Mediator.Commands.AddressCommands;
using Footwear.Application.Validator.AddressValidator;
using Footwear.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Handlers.AddressHandlers
{
    public class DeleteAddressCommandHandler: IRequestHandler<DeleteAddressCommand, Response<object>>
    {
        private readonly IRepository<Address> _repository;

        public DeleteAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<Response<object>> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            DeleteAddressCommandValidator validationRules = new DeleteAddressCommandValidator();
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
                response.ResponseMessage = "Kayıt silinirken sorun yaşandı.";
                return response;
            }
            var value = await _repository.GetSingleByIdAsync(request.Id);
            if(value is null)
                return new Response<object>
                {
                    ResponseStatusCode = (int)HttpStatusCode.NotFound,
                    ResponseData = null,
                    ResponseIsSuccessfull = false,
                    ResponseMessage = "Silinecek kayıt bulunamadı"
                };
            await _repository.DeleteAsync(request.Id);
            return new Response<object>
            {
                ResponseStatusCode = (int)HttpStatusCode.OK,
                ResponseData = "Kayıt silindi",
                ResponseIsSuccessfull = true,
                ResponseMessage = "Kayıt başarıyla silindi"
            };
        }
    }
}
