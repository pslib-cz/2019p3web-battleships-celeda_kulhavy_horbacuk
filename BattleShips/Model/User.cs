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
        public ICollection<Game> CreatedGames { get; set; }
        public ICollection<Game> GamesOnTurn { get; set; }
        public ICollection<UserGame> Games { get; set; }
        public ICollection<ShipUserPlaced> ShipUserPlaceds { get; set; }
        public ICollection<ShipUserNotPlaced> ShipUserNotPlaced { get; set; }

    }
}
