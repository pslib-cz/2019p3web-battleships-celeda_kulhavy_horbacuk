using Microsoft.AspNetCore.Identity;
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
        public int GameSize { get; set; }

        public string PlayerOnTurnId { get; set; }
        [ForeignKey("PlayerOnTurnId")]
        public User PlayerOnTurn { get; set; }

        public string OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public User Owner { get; set; }

        public ICollection<UserGame> UserGames { get; set; }
        public ICollection<ShipGame> ShipsForGame { get; set; }

        public GameState GameState { get; set; }
    }
}
