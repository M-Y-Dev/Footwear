using Footwear.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Domain.Entities
{
    public class Basket : BaseEntity
    {
        public int UserId { get; set; }
        public List<BasketItem> BasketItem { get; set; }
        public decimal TotalAmount => BasketItem?.Sum(item => item.TotalPrice) ?? 0;
    }
}
