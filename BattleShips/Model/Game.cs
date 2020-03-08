using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Model
{
    public class Game
    {
        [Key]
        public Guid GameId { get; set; }
        public int MaxPlayers { get; set; }
        public string OwnerId { get; set; }
        public string CurrentPlayerId { get; set; }
        public int GameSize { get; set; }
        [ForeignKey("CurrentPlayerId")]
        public User CurrentUser { get; set; }
        [ForeignKey("OwnerId")]
        public User User { get; set; }
        public enum GameState
        { 
            Setup = 0,
            Battle = 1,
            End = 2
        }
    }
}
