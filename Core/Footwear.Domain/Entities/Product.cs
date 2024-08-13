using Footwear.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public string ProductImageUrl { get; set; }
        public int ProductStock { get; set; }
        public decimal Price { get; set; }
        public int Size { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public bool IsWoman { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public List<ProductDetail> ProductDetails { get; set; }
    }

}
