using BattleShips.Model;
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
        public IQueryable<IQueryable<NavyBattlePiece>> GameBoard(IList<NavyBattlePiece> navyBattlePieces)
        {
            int Rows = 10;
            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Rows; column++)
                { 
                    
                }
            }
        }
    }
}
