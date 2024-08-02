﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Results.ProductResults
{
    public class GetProductWithCategoryQueryResult
    {
        public string ProductName { get; set; }
        public string ProductImageUrl { get; set; }
        public int ProductStock { get; set; }
        public decimal Price { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
