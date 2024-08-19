using Footwear.Application.Base;
using Footwear.Application.Mediator.Results.BannerResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Queries.BannerQueries
{
    public class GetBannerQuery : IRequest<Response<List<GetBannerQueryResult>>>
    {
    }
}
