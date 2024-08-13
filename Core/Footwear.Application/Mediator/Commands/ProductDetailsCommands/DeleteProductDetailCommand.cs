using Footwear.Application.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Commands.ProductDetails
{
    public class DeleteProductDetailCommand : IRequest<Response<object>>
    {
        public int Id { get; set; }

        public DeleteProductDetailCommand(int id)
        {
            Id = id;
        }
    }
}
