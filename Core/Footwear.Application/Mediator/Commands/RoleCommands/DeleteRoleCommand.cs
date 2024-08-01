using Footwear.Application.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Commands.RoleCommands
{
    public class DeleteRoleCommand : IRequest<Response<object>>
    {
        public int RoleId { get; set; }

        public DeleteRoleCommand(int roleId)
        {
            RoleId = roleId;
        }
    }
}
