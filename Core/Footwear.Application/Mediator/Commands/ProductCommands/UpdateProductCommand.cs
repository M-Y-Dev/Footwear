using Footwear.Application.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Commands.ProductCommands
{
    public class UpdateProductCommand :IRequest<Response<object>>
    {
        public  int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductImageUrl { get; set; }
        public int ProductStock { get; set; }
        public decimal Price { get; set; }
        public int Size { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public bool IsWoman { get; set; }
        public int CategoryID { get; set; }
    }
}
