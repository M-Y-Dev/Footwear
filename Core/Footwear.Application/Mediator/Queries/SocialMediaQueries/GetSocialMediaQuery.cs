﻿using Footwear.Application.Base;
using Footwear.Application.Mediator.Results.SocialMediaResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Queries.SocialMediaQueries
{
    public class GetSocialMediaQuery:IRequest<Response<List<GetSocialMediaQueryResult>>>
    {
    }
}
