using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Model
{
    public class ShipUser
    {
        public int ShipId { get; set; }
        [ForeignKey("ShipId")]
        public Ship Ship { get; set; }

        public int UserGameId { get; set; }
        [ForeignKey("UserGameId")]
        public UserGame UserGame { get; set; }
    }
}
