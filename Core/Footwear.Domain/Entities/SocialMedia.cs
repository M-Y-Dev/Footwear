using Footwear.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Domain.Entities
{
    public class SocialMedia:BaseEntity
    {
        public string Url { get; set; }
        public string Icon { get; set; }
    }
}
