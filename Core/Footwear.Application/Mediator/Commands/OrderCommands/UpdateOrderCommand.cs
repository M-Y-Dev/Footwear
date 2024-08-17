using Footwear.Application.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Commands.OrderCommands;

public class UpdateOrderCommand : IRequest<Response<object>>
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string OrderNumber { get; set; }
    public decimal TotalAmount { get; set; }
    public string ShippingAddress { get; set; }
    public string Status { get; set; }
}
