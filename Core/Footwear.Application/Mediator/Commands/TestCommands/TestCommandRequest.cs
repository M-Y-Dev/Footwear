using Footwear.Application.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Commands.TestCommands
{
    public class TestCommandRequest:IRequest<Response<TestCommandResponse>>
    {
        public int Id { get; set; }
    }
}
