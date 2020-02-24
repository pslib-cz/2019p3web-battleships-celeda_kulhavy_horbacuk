using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Model
{
    public class UserGame
    {
        public string UserId { get; set; }
        public Guid GameId { get; set; }
        [ForeignKey("GameId")]
        public Game Game { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
