﻿using BattleShips.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Services
{
    public interface IGame
    {
        IList<ShipPiece> Ships(); //List lodí
        public void Shooting(/*pozice, kdo*/);
        public void EndCheck();//kontrola stavu hry
        public void BoxCheck();//kontrola herních políček
        public void Fire(int navyBattlePieceId);
    }
}
