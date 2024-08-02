using AutoMapper;
using Footwear.Application.Base;
using Footwear.Application.Interfaces;
using Footwear.Application.Mediator.Queries.ContactQueries;
using Footwear.Application.Mediator.Results.ContactResults;
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
    public class GetContactQueryHandler: IRequestHandler<GetContactQuery, Response<List<GetContactQueryResult>>>
    {
        private readonly IRepository<Contact> _repository;
        private readonly IMapper _mapper;

        public GetContactQueryHandler(IRepository<Contact> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<List<GetContactQueryResult>>> Handle(GetContactQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            if (values.Any())
                return new Response<List<GetContactQueryResult>>
                {
                    ResponseIsSuccessfull = true,
                    ResponseData = _mapper.Map<List<GetContactQueryResult>>(values),
                    ResponseMessage = "Kayıtlar başarıyla getirildi",
                    ResponseStatusCode = (int)HttpStatusCode.OK
                };
            return new Response<List<GetContactQueryResult>>
            {
                ResponseIsSuccessfull = false,
                ResponseData = _mapper.Map<List<GetContactQueryResult>>(values),
                ResponseMessage = "Listelenecek kayıt bulunamadı",
                ResponseStatusCode = (int)HttpStatusCode.NotFound,
            };
        }
    }
}
