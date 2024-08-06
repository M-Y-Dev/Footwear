using Footwear.Application.Base;
using Footwear.Application.Mediator.Results.AddressResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Queries.AddressQueries
{
    public class GetAddressQuery: IRequest<Response<List<GetAddressQueryResult>>>
    {
    }
}
