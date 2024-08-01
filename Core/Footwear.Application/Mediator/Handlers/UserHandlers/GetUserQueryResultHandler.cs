using AutoMapper;
using Footwear.Application.Base;
using Footwear.Application.Interfaces;
using Footwear.Application.Mediator.Queries.UserQueries;
using Footwear.Application.Mediator.Results.RoleResults;
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
    public class GetUserQueryResultHandler : IRequestHandler<GetUserQuery, Response<List<GetUserQueryResult>>>
    {
        private readonly IRepository<AppUser> _userRepository;
        private readonly IMapper _mapper;

        public GetUserQueryResultHandler(IRepository<AppUser> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Response<List<GetUserQueryResult>>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var values = await _userRepository.GetAllAsync();
            if(values.Any())
            {
                return new Response<List<GetUserQueryResult>>
                {
                    ResponseIsSuccessfull = true,
                    ResponseData = _mapper.Map<List<GetUserQueryResult>>(values),
                    ResponseMessage = "Kayıtlar başarılı bir şekilde getirildi.",
                    ResponseStatusCode = (int)HttpStatusCode.OK
                };
            }
            else
            {
                return new Response<List<GetUserQueryResult>>
                {
                    ResponseIsSuccessfull = false,
                    ResponseData = _mapper.Map<List<GetUserQueryResult>>(values),
                    ResponseMessage = "Listelenecek Kayıt Bulunamadı",
                    ResponseStatusCode = (int)HttpStatusCode.NotFound
                };
            }
            throw new NotImplementedException();
        }
    }
}
