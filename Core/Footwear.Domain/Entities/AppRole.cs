using Footwear.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Domain.Entities
{
    public class AppRole : BaseEntity
    {
        public string RoleName { get; set; }
        public List<AppUser> AppUsers { get; set; }
    }

}
