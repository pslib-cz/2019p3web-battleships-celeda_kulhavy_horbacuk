using BattleShips.Helpers;
using BattleShips.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BattleShips.Services
{
    public class InGame : IGame
    {
        private readonly ApplicationDbContext _db;
        private readonly ISession _session;
        private readonly IHttpContextAccessor _http;
        public Guid CurrentGameId { get; set; }
        public InGame(ApplicationDbContext db, IHttpContextAccessor http)
        {
            _db = db;
            _http = http;
            _session = http.HttpContext.Session;
            CurrentGameId = LoadGame("Game");
        }

        public void BoxCheck()
        {
            throw new NotImplementedException();
        }

        public void EndCheck()
        {
            throw new NotImplementedException();
        }

        public Guid LoadGame(string id)
        {
            Guid loadId = _session.Get<Guid>(id);
            //loadId = (Guid)Activator.CreateInstance(typeof(Guid));
            return loadId;
        }

        public void SaveGame(string id, Guid guid)
        {
            _session.Set(id, guid);
        }

        public void Fire(int? navyBattlePieceId)
        {
            if(navyBattlePieceId != null)
            {

                NavyBattlePiece battlePiece = _db.NavyBattlePieces.Where(p => p.Id == navyBattlePieceId).SingleOrDefault();

                Game currentgame = GetCurrentGame();
                UserGame activeUserGame = _db.UserGames.Where(m => m.UserId == currentgame.PlayerOnTurn.ToString()).AsNoTracking().SingleOrDefault();

                string activeUserId = GetActiveUserId();
                UserGame ShootersGame = _db.UserGames.Where(u => u.UserId == activeUserId)
                .Include(u => u.Game)
                .AsNoTracking().SingleOrDefault();

                if (currentgame.GameState == GameState.End)
                {
                    //pro případ palby po konci hry
                }
                if (battlePiece.UserGameId == ShootersGame.Id)
                {
                    //kontrola střelby na vlastní políčka
                }
                if (battlePiece.PieceState == PieceState.DeadShip)
                {
                    //již trefená loď (hráč by neměl přijít o kolo, jen dostat upozornění)
                }
                if (battlePiece.PieceState == PieceState.DeadWater)
                {
                    //již trefená voda (hráč by neměl přijít o kolo, jen dostat upozornění)
                }

                PieceState newState;
                switch (battlePiece.PieceState)
                {
                    case PieceState.Ship:
                        newState = PieceState.DeadShip;
                        break;
                    case PieceState.Water:
                        newState = PieceState.DeadWater;
                        break;
                    default:
                        newState = battlePiece.PieceState;
                        break;
                }
                battlePiece.PieceState = newState;
                _db.SaveChanges();
                
            }

        }

        public List<NavyBattlePiece> GetNavyBattlePieces(int userGameId)
        {
            var pieces = _db.NavyBattlePieces.Where(g => g.UserGameId == userGameId).ToList();
            return pieces;
        }

        public IList<ShipPiece> Ships()
        {
            throw new NotImplementedException();
        }

        public void Shooting()
        {
            throw new NotImplementedException();
        }

        public Game GetCurrentGame()
        {
            Guid currentGameId = CurrentGameId;
            return _db.Games.Where(x => x.GameId == currentGameId).AsNoTracking().SingleOrDefault();
        }

        public string GetActiveUserId()
        {
            var output = _http.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return output;
        }
        public IList<UserGame> GetUserGames()
        {
            Guid gameId = CurrentGameId;
            return _db.UserGames.Where(g => g.GameId == CurrentGameId).Include(u => u.User).Include(g => g.Game).ToList();
        }
    }
}
