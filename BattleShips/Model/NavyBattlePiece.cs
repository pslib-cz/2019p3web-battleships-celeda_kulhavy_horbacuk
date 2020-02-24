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
        public int TypeId { get; set; }
        public string UserId { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
