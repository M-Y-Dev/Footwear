using Footwear.Application.Base;
using Footwear.Application.Mediator.Results.BrandResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Queries.BrandQueries
{
    public class GetBrandByIdQuery : IRequest<Response<GetBrandByIdQueryResult>>
    {
        public int Id { get; set; }

        public GetBrandByIdQuery ( int id )
        {
            Id = id;
        }
    }
}
