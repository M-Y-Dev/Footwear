using Footwear.Application.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Commands.AddressCommands
{
    public class CreateAddressCommand: IRequest<Response<object>>
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string AddressDetail { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }

        }
}
