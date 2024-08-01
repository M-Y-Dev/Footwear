using Footwear.Application.Base;
using MediatR;

namespace Footwear.Application.Mediator.Commands.UserCommands
{
    public class CreateUserCommand : IRequest<Response<object>>
    {
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
