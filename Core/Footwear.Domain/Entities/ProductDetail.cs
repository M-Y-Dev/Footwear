using Footwear.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Domain.Entities
{
    public class ProductDetail : BaseEntity
    {
        public string ProductInfo { get; set; }
        public int Rating { get; set; }
        public string ImageUrlDetail1 { get; set; }
        public string ImageUrlDetail2 { get; set; }
        public string ImageUrlDetail3 { get; set; }
        public string Description { get; set; }
        public string CompanyInformation { get; set; }
        public int ProductId { get; set; }
        public  Product Product { get; set; }
    }

}
