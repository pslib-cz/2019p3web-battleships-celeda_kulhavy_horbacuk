﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Model
{
    public enum PieceState
    {
        Water = 0,
        Ship = 1,
        DeadWater = 2,
        DeadShip = 3,
        Margin = 4,
    }
}
