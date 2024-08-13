using Footwear.Application.Base;
using Footwear.Application.Mediator.Results.BasketItemResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Queries.BasketItemQueries
{
    public class GetBasketItemByIdQuery : IRequest<Response<GetBasketItemByIdQueryResult>>
    {
        public int Id { get; set; }

        public GetBasketItemByIdQuery(int id)
        {
            Id = id;
        }
    }
}
