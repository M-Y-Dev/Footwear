using Footwear.Application.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Commands.BannerCommands
{
    public class CreateBannerCommand: IRequest<Response<object>>
    {
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

    }
}
