﻿using Footwear.Application.Base;
using Footwear.Application.Mediator.Results.BasketResults;
using Footwear.Application.Mediator.Results.ProductResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Queries.BasketQueries
{
    public class GetBasketQuery : IRequest<Response<List<GetBasketQueryResult>>>
    {
    }
}
