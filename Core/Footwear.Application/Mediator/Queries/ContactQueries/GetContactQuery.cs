using Footwear.Application.Base;
using Footwear.Application.Mediator.Results.ContactResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Queries.ContactQueries
{
    public class GetContactQuery: IRequest<Response<List<GetContactQueryResult>>>
    {
    }
    
}
