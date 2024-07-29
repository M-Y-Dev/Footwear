using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Footwear.Persistance.Context
{
    public class FootwearContext:DbContext
    {
        public FootwearContext(DbContextOptions<FootwearContext> context):base(context)
        {
            
        }
    }
}
