using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Model
{
    public class UserDbContext : IdentityDbContext
    {
        public DbSet<User> Data { get; set; }
    }
}
