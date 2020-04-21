using BattleShips.Helpers;
using BattleShips.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Services
{
    public class InGame : IGame
    {
        private readonly ApplicationDbContext _db;
        private readonly ISession _session;
        private readonly IHttpContextAccessor _http;
        public InGame(ApplicationDbContext db, IHttpContextAccessor http)
        {
            _db = db;
            _http = http;
            _session = http.HttpContext.Session;
        }

        public void BoxCheck()
        {
            throw new NotImplementedException();
        }

        public void EndCheck()
        {
            throw new NotImplementedException();
        }
        public string PieceColorManagement(int navyBattlePieceId)
        {
            NavyBattlePiece battlePiece = _db.NavyBattlePieces.Where(p => p.Id == navyBattlePieceId).SingleOrDefault();



            switch (battlePiece.PieceState)
            {
                case PieceState.Ship:
                    return "black";
                case PieceState.DeadShip:
                    return "red";
                case PieceState.Water:
                    return "";

                case PieceState.Margin:

                default:
                    break;
            }

            _db.SaveChanges();
        }

        //public void Water()
        //{ 

        //}
        public Guid LoadGame(string id)
        {
            Guid loadId = _session.Get<Guid>(id);
            loadId = (Guid)Activator.CreateInstance(typeof(Guid));
            return loadId;
        }

        public void SaveGame(string id, Guid guid)
        {
            _session.Set(id, guid);
        }

        public void Fire(int navyBattlePieceId)
        {
            NavyBattlePiece battlePiece = _db.NavyBattlePieces.Where(p => p.Id == navyBattlePieceId).SingleOrDefault();
            PieceState newState;
            switch(battlePiece.PieceState)
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
                    newState = battlePiece.PieceState;
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
