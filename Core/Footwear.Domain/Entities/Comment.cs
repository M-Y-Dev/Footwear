using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Footwear.Domain.Entities.Common;

namespace Footwear.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string ProductId { get; set; }
        public string CommentDetail { get; set; }
        public bool Status { get; set; }
    }
}
