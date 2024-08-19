using Footwear.Application.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Commands.BrandCommand
{
    public class DeleteBrandCommand : IRequest<Response<object>>
    {
        public int Id { get; set; }

        public DeleteBrandCommand(int id)
        {
            Id = id;
        }
    }
}
