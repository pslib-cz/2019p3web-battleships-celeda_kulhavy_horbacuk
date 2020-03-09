using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Model
{
    public class User : IdentityUser
    {
        [Key]
        public IdentityUser IdentityUser { get; set; }

        public ICollection<Game> Game { get; set; }
        public ICollection<UserGame> Games { get; set; }
        public ICollection<ShipUser> ShipUsers { get; set; }
    }
}
