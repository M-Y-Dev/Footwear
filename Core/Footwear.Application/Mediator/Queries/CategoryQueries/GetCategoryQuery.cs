using Footwear.Application.Base;
using Footwear.Application.Mediator.Results.CategoryResults;
using Footwear.Application.Mediator.Results.ProductResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Queries.CategoryQueries
{
    public class GetCategoryQuery : IRequest<Response<List<GetCategoryQueryResult>>>
    {
    }
}
