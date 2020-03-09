using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Model
{
    public class NavyBattlePiece
    {
        [Key]
        public int Id { get; set; }

        public int PosX { get; set; }
        public int PosY { get; set; }

        public string UserGameId { get; set; }
        [ForeignKey("UserGameId")]
        public UserGame UserGame { get; set; }

        public int ShipId { get; set; } //Type
        [ForeignKey("ShipId")]
        public Ship Ship { get; set; }

        public bool Hidden { get; set; }
        public enum PieceState
        { 
            Water = 0,
            Ship = 1,
            DeadWater = 2,
            DeadShip = 3,
            Margin = 4
        }
    }
}
