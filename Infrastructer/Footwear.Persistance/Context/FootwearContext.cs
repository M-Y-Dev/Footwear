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
        public DbSet<About> Abouts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<SocialMedia> SocialMedias{ get; set; }
    }
}
