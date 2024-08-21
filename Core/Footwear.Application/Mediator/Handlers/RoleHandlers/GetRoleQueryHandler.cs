using AutoMapper;
using Footwear.Application.Base;
using Footwear.Application.Interfaces;
using Footwear.Application.Mediator.Queries.RoleQueries;
using Footwear.Application.Mediator.Results.RoleResults;
using Footwear.Application.Mediator.Results.SocialMediaResults;
using Footwear.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Handlers.RoleHandlers
{
    public class GetRoleQueryHandler : IRequestHandler<GetRoleQuery, Response<List<GetRoleQueryResult>>>
    {
        private readonly IRepository<AppRole> _roleRepository;
        private readonly IMapper _mapper;

        public GetRoleQueryHandler(IRepository<AppRole> roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<Response<List<GetRoleQueryResult>>> Handle(GetRoleQuery request, CancellationToken cancellationToken)
        {
            var values = await _roleRepository.GetAllAsync();

            if(values.Any())
            {
                return new Response<List<GetRoleQueryResult>>
                {
                    ResponseIsSuccessfull = true,
                    ResponseData = _mapper.Map<List<GetRoleQueryResult>>(values),
                    ResponseMessage = "Kayıtlar başarılı bir şekilde getirildi.",
                    ResponseStatusCode = (int)HttpStatusCode.OK
                };

            }
            else
            {
                return new Response<List<GetRoleQueryResult>>
                {
                    ResponseIsSuccessfull = false,
                    ResponseData = _mapper.Map<List<GetRoleQueryResult>>(values),
                    ResponseMessage = "Listelenecek Kayıt Bulunamadı",
                    ResponseStatusCode = (int)HttpStatusCode.NotFound
                };
            }
        }
    }
}
