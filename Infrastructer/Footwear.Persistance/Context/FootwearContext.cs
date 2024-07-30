using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Footwear.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Footwear.Persistance.Context
{
    public class FootwearContext:DbContext
    {
        public FootwearContext(DbContextOptions<FootwearContext> context):base(context)
        {
            
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
