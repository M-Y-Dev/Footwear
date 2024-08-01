using Footwear.Application.Base;
using Footwear.Application.Mediator.Results.RoleResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Queries.RoleQueries
{
    public class GetRoleQuery : IRequest<Response<List<GetRoleQueryResult>>>
    {
    }
}
