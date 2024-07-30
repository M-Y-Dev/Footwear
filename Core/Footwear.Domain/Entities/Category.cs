using Footwear.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public List<Product> Products { get; set; }
    }
}
