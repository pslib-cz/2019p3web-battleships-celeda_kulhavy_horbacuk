using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Model
{
    public class GameBoard
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public IList<NavyBattlePiece> Board { get; set; }

    }
}
