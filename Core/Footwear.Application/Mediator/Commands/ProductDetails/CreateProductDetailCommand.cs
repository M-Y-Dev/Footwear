using Footwear.Application.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Commands.ProductDetails
{
    public class CreateProductDetailCommand : IRequest<Response<object>>
    {
        public string ProductInfo { get; set; }
        public int Rating { get; set; }
        public string ImageUrlDetail1 { get; set; }
        public string ImageUrlDetail2 { get; set; }
        public string ImageUrlDetail3 { get; set; }
        public string Description { get; set; }
        public string CompanyInformation { get; set; }
        public int ProductId { get; set; }
        public DateTime CreatedDate { get => DateTime.Now; }
    }
}
