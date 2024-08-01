using Footwear.Application.Base;
using Footwear.Application.Mediator.Results.SocialMediaResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Queries.SocialMediaQueries
{
    public class GetSocialMediaByIdQuery:IRequest<Response<GetSocialMediaByIdQueryResult>>
    {
        public int Id { get; set; }

        public GetSocialMediaByIdQuery(int id)
        {
            Id = id;
        }
    }
}
