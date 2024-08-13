﻿using Footwear.Application.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Commands.BasketCommands
{
    public class CreateBasketCommand : IRequest<Response<object>>
    {
        public int UserId { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
