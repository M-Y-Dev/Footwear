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
    public class GetAppUserListWithRoleQuery : IRequest<Response<List<GetAppUserListWithRoleQueryResult>>>
    {
    }
}
