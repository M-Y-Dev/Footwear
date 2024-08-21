using AutoMapper;
using Footwear.Application.Base;
using Footwear.Application.Interfaces;
using Footwear.Application.Mediator.Queries.UserQueries;
using Footwear.Application.Mediator.Results.ProductResults;
using Footwear.Application.Mediator.Results.UserResults;
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
    public class GetUserListWithRoleQueryHandler : IRequestHandler<GetAppUserListWithRoleQuery, Response<List<GetAppUserListWithRoleQueryResult>>>
    {
        private readonly IRepository<AppUser> _repository;
        private readonly IMapper _mapper;

        public GetUserListWithRoleQueryHandler(IRepository<AppUser> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<List<GetAppUserListWithRoleQueryResult>>> Handle(GetAppUserListWithRoleQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync(filter: null, includes: x => x.AppRole);
            if (values.Any())
                return new Response<List<GetAppUserListWithRoleQueryResult>>
                {
                    ResponseIsSuccessfull = true,
                    ResponseData = _mapper.Map<List<GetAppUserListWithRoleQueryResult>>(values),
                    ResponseMessage = "Kayıtlar başarıyla getirildi",
                    ResponseStatusCode = (int)HttpStatusCode.OK,
                };
            return new Response<List<GetAppUserListWithRoleQueryResult>>
            {
                ResponseIsSuccessfull = false,
                ResponseData = _mapper.Map<List<GetAppUserListWithRoleQueryResult>>(values),
                ResponseMessage = "Listelenecek kayıt bulunamadı",
                ResponseStatusCode = (int)HttpStatusCode.NotFound,
            };
        }
    }
}
