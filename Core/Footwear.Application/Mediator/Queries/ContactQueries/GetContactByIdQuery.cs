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
    public class GetContactByIdQuery: IRequest<Response<GetContactByIdQueryResult>>
    {
        public int Id { get; set; }

        public GetContactByIdQuery(int contactId)
        {
            Id = contactId;
        }
    }
    
}
