using Footwear.Application.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Commands.BrandCommand
{
    public class UpdateBrandCommand : IRequest<Response<object>>
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}
