﻿using BattleShips.Model;
using BattleShips.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.ViewModel
{
    public class GameBoardModel
    {
        public IGame _igame;
        public Game Game { get; set; }
        public UserGame UserGame { get; set; }
        public IList<NavyBattlePiece> _navyBattlePieces { get; set; }
        public string UserName { get; set; }
        public GameBoardModel(IList<NavyBattlePiece> navyBattlePieces, UserGame userGame, string userName)
        {
            _navyBattlePieces = navyBattlePieces;
            UserGame = userGame;
            Game = userGame.Game;
            UserName = userName;
        }
        public IEnumerable<IGrouping<int, NavyBattlePiece>> GameBoard(IList<NavyBattlePiece> navyBattlePieces)
        {
            return navyBattlePieces.OrderBy(n => n.PosY).ThenBy(n => n.PosX).GroupBy(n => n.PosY);
        }
    }
}