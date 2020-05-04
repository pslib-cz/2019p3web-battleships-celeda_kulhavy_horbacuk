﻿using BattleShips.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.ViewModel
{
    public class GameBoardModel
    {
        public Game Game { get; set; }
        public UserGame UserGame { get; set; }
        public List<NavyBattlePiece> _navyBattlePieces { get; set; }

        public GameBoardModel(List<NavyBattlePiece> navyBattlePieces)
        {
            _navyBattlePieces = navyBattlePieces;
        }
        public IEnumerable<IGrouping<int, NavyBattlePiece>> GameBoard(IList<NavyBattlePiece> navyBattlePieces)
        {
            return navyBattlePieces.OrderBy(n => n.PosY).ThenBy(n => n.PosX).GroupBy(n => n.PosY);
        }
    }
}