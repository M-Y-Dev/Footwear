using Footwear.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Mediator.Results.RoleResults
{
    public class GetRoleByIdQueryResult
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
}
