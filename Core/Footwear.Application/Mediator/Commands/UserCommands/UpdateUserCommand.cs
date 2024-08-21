using Footwear.Application.Base;
using Footwear.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Commands.UserCommands
{
    public class UpdateUserCommand : IRequest<Response<object>>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string ImageUrl { get; set; }
        public int RoleId { get; set; }
        public string Password { get; set; }
    }
}
