using Footwear.Application.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Commands.SocialMediaCommands
{
    public class CreateSocialMediaCommand:IRequest<Response<object>>
    {
        public string Url { get; set; }
        public string Icon { get; set; }
        public DateTime CreatedDate { get => DateTime.Now; } 
    }
}
