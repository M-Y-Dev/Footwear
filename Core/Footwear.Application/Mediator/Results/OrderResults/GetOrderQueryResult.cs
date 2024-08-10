using Footwear.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Results.OrderResults;

public class GetOrderQueryResult
{
    public int UserId { get; set; }
    public string OrderNumber { get; set; }
    public decimal TotalAmount { get; set; }
    public string ShippingAddress { get; set; }
    public string Status { get; set; }
}
