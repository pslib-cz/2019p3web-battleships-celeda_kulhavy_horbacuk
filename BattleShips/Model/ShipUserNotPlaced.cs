using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Model
{
    public class ShipUserNotPlaced
    {
        public int ShipId { get; set; }
        [ForeignKey("ShipId")]
        public Ship Ship { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
