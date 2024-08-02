using Footwear.Application.Interfaces;
using Footwear.Domain.Entities;
using Footwear.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Persistance.Repositories
{
    public class ProductRespository :IProductRespository
    {
        private readonly FootwearContext _context;

        public ProductRespository(FootwearContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProductListWithCategory()
        {
            var values = await _context.Products.Include(x => x.Category).ToListAsync();
            return values;
        }
    }
}
