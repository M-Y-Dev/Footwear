using Footwear.Application.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Commands.CategoryCommands
{
    public class CreateCategoryCommand : IRequest<Response<object>>
    {
        public string CategoryName { get; set; }
        public DateTime CreatedDate { get => DateTime.Now; }
    }
}
