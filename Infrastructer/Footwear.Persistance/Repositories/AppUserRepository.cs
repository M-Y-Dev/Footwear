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
    public class AppUserRepository : IAppUserRepository
    {
        private readonly FootwearContext _context;

        public AppUserRepository(FootwearContext context)
        {
            _context = context;
        }

        public async Task<List<AppUser>> GetAppUserWithRoleAsync()
        {
            var values = await _context.AppUsers.Include(x=>x.AppRole).ToListAsync();
            return values;
        }
    }
}
