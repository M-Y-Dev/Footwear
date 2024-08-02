using Footwear.Application.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Commands.CommentCommands
{
    public class DeleteCommentCommand:IRequest<Response<object>>
    {
        public int Id { get; set; }

        public DeleteCommentCommand(int id)
        {
            Id = id;
        }
    }
}
