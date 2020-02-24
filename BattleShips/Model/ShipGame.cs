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
        public int ShipId { get; set; }
        [Key]
        public int GameId { get; set; }
        [ForeignKey("ShipId")]
        public Ship Ship { get; set; }
        [ForeignKey("GameId")]
        public Game Game { get; set; }
    }
}
