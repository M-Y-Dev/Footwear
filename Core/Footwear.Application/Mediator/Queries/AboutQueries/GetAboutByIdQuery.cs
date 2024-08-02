using Footwear.Application.Base;
using Footwear.Application.Mediator.Results.AboutResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Queries.AboutQueries
{
    public class GetAboutByIdQuery:IRequest<Response<GetAboutByIdQueryResult>>
    {
        public int Id { get; set; }

        public GetAboutByIdQuery(int id)
        {
            Id = id;
        }
    }
}
