using Footwear.Application.Base;
using Footwear.Application.Mediator.Results.UserResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Queries.UserQueries
{
    public class GetUserByIdQuery : IRequest<Response<GetUserByIdQueryResult>>
    {
        public int Id { get; set; }

        public GetUserByIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
