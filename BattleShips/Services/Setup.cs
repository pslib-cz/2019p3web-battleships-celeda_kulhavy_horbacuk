using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleShips.Model;
using BattleShips.Services;

namespace BattleShips.Services
{
    public class Setup : ISetup
    {
        public ApplicationDbContext _db;
        public Setup(ApplicationDbContext db)
        {
            _db = db;
        }

        public ShipGame CreateShipGame(int shipid, Guid gameid)
        {
            var ship = _db.Ships.SingleOrDefault(s => s.Id == shipid);
            var game = _db.Games.SingleOrDefault(g => g.GameId == gameid);
            return new ShipGame() { Ship = ship, Game = game };
        }
        public bool AddShipGame(int shipid, Guid gameid)
        {
            var shipgame = CreateShipGame(shipid, gameid);
            _db.SaveChanges();
            return true;
        }
        public bool AddShipGame(ShipGame shipGame)
        {
            var shipgame = _db.ShipGames.SingleOrDefault(s => s.ShipId == shipGame.ShipId && s.GameId == shipGame.GameId);
            if (!(shipgame is null)) return false;
            _db.ShipGames.Add(shipGame);
            _db.SaveChanges();
            return true;
        }

        public string AddShipColorManagement(int navyBattlePieceId)
        {
            NavyBattlePiece battlePiece = _db.NavyBattlePieces.Where(p => p.Id == navyBattlePieceId).SingleOrDefault(); // nevim jak tohle funguje takže nevim jestli to tu vubec ma bejt

            switch (battlePiece.PieceState)
            {
                case PieceState.Ship:
                    return "black";
                case PieceState.Margin:
                    return "white";
                default:
                    return "";
            }
        }

        //Metody ktere by měli fungovat po předělani poliček na NavyBattlePiece:

        //public void AddShip(int navyBattlePieceId)
        //{
        //    NavyBattlePiece battlePiece = //_db.NavyBattlePieces.Where(p => p.Id == navyBattlePieceId).SingleOrDefault(); // nevim jak tohle funguje :(
        //    battlePiece.PieceState = PieceState.Ship;
        //}

        //public void MarginToWater() //nevim jestli tahle metoda je spravně udělana :D
        //{
        //    foreach (NavyBattlePiece BattlePiece in _db.NavyBattlePieces)
        //    {
        //        if (BattlePiece.PieceState == PieceState.Margin)
        //        {
        //            BattlePiece.PieceState = PieceState.Water;
        //        }
        //    }
        //}

        public InGame GetGame(int id)
        {
            throw new NotImplementedException();
        }

        public UserGame GetUserGame(string userId, int gameId)
        {
            throw new NotImplementedException();
        }

        public void Ready()
        {
            throw new NotImplementedException();
        }

        public void ShipsReady()
        {
            throw new NotImplementedException();
        }
        public List<Ship> GetShips()
        {
            return _db.Ships.ToList();
        }
    }
}
