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
    public class GetAboutQuery:IRequest<Response<List<GetAboutQueryResult>>>
    {
    }
}
