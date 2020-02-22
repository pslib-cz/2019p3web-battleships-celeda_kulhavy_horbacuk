using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Model
{
    public class Game
    {
        [Key]
        public Guid GameId { get; set; }
        public int MaxPlayers { get; set; }
        public int OwnerId { get; set; }
        public int CurrentPlayerId { get; set; }
        public int GameSize { get; set; }
    }
}
