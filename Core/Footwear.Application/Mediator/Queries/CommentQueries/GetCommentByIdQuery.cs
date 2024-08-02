using Footwear.Application.Base;
using Footwear.Application.Mediator.Results.CommentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Queries.CommentQueries
{
    public class GetCommentByIdQuery:IRequest<Response<GetCommentByIdQueryResult>>
    {
        public int Id { get; set; }

        public GetCommentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
