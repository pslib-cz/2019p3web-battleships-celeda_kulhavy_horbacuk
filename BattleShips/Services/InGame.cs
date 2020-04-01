using BattleShips.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Services
{
    public class InGame : IGame
    {
        private ApplicationDbContext _db;
        public InGame(ApplicationDbContext db)
        {
            _db = db;
        }

        public void BoxCheck()
        {
            throw new NotImplementedException();
        }

        public void EndCheck()
        {
            throw new NotImplementedException();
        }

        public void Fire(int navyBattlePieceId, PieceState pieceState)
        {
            NavyBattlePiece battlePiece = _db.NavyBattlePieces.Where(p => p.Id == navyBattlePieceId).SingleOrDefault();
            PieceState newState;
            switch(pieceState)
            {
                case PieceState.Ship:
                    newState = PieceState.DeadShip;
                    break;
                case PieceState.Water:
                    newState = PieceState.DeadWater;
                    break;
                case PieceState.Margin:
                    newState = PieceState.DeadWater;
                    break;
                default:
                    newState = PieceState.Water;
                    break;
            }
            battlePiece.PieceState = newState;
            _db.SaveChanges();
        }

        public IList<ShipPiece> Ships()
        {
            throw new NotImplementedException();
        }

        public void Shooting()
        {
            throw new NotImplementedException();
        }
    }
}
