﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Model
{
    public class Ship
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ShipPiece> ShipPieces { get; set; }
        public ICollection<ShipGame> ShipGames { get; set; }
        public ICollection<ShipUser> ShipUsers { get; set; }
        public ICollection<NavyBattlePiece> NavyBattlePieces { get; set; }
    }
}
