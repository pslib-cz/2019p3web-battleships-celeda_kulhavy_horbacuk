using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Model
{
    public class UserGame
    {
        public Guid GameId { get; set; }
        [ForeignKey("GameId")]
        public Game Game { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public ICollection<NavyBattlePiece> NavyBattlePieces { get; set; }
        public ICollection<ShipGame> ShipGames { get; set; }

        public PlayerState PlayerState { get; set; }
    }
}
