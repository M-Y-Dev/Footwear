using Footwear.Application.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Commands.CommentCommands
{
    public class CreateCommentCommand:IRequest<Response<object>>
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string ProductId { get; set; }
        public string CommentDetail { get; set; }
        public bool Status { get; set; }
    }
}
