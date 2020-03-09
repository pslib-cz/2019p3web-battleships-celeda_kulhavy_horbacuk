using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Model
{
    public class ShipGame
    {
        [Key]
        public int Id { get; set; }

        public int ShipId { get; set; }
        [ForeignKey("ShipId")]
        public Ship Ship { get; set; }

        public Guid GameId { get; set; }
        [ForeignKey("GameId")]
        public Game Game { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Game> Games { get; set; }
        public ICollection<UserGame> UserGames { get; set; }
    }
}
