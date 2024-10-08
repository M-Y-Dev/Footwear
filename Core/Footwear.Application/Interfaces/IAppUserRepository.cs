﻿using Footwear.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Interfaces
{
    public interface IAppUserRepository
    {
        Task<List<AppUser>> GetAppUserWithRoleAsync();
    }
}
