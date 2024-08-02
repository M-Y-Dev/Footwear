using AutoMapper;
using Footwear.Application.Base;
using Footwear.Application.Interfaces;
using Footwear.Application.Mediator.Queries.CommentQueries;
using Footwear.Application.Mediator.Results.AboutResults;
using Footwear.Application.Mediator.Results.CommentResults;
using Footwear.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Handlers.CommentHandlers
{
    public class GetCommentQueryHandler : IRequestHandler<GetCommentQuery, Response<List<GetCommentQueryResult>>>
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public GetCommentQueryHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<List<GetCommentQueryResult>>> Handle(GetCommentQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            if (values.Any())
                return new Response<List<GetCommentQueryResult>>
                {
                    ResponseIsSuccessfull = true,
                    ResponseData = _mapper.Map<List<GetCommentQueryResult>>(values),
                    ResponseMessage = "Kayıtlar başarıyla getirildi",
                    ResponseStatusCode = (int)HttpStatusCode.OK
                };
            return new Response<List<GetCommentQueryResult>>
            {
                ResponseIsSuccessfull = false,
                ResponseData = _mapper.Map<List<GetCommentQueryResult>>(values),
                ResponseMessage = "Listelenecek kayıt bulunamadı",
                ResponseStatusCode = (int)HttpStatusCode.NotFound,
            };
        }
    }
}
