using Footwear.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Domain.Entities;

public class Order : BaseEntity
{
    public int UserId { get; set; }
    public AppUser User { get; set; }
    public string OrderNumber { get; set; } 
    public decimal TotalAmount { get; set; }
    public string ShippingAddress { get; set; }
    public string Status { get; set; }
    public List<OrderDetail> OrderDetails { get; set; }
}
