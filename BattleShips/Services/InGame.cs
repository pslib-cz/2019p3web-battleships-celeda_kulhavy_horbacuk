using BattleShips.Helpers;
using BattleShips.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
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
        private string _user;
        public Guid CurrentGameId { get; set; }
        public InGame(ApplicationDbContext db, IHttpContextAccessor http, Identity identity)
        {
            _db = db;
            _http = http;
            _session = http.HttpContext.Session;
            CurrentGameId = LoadGame("Game");
            _user = identity.LoginId;
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
            return loadId;
        }

        public void SaveGame(string id, Guid guid)
        {
            _session.Set(id, guid);
        }
        public string Fire(int? navyBattlePieceId)
        {
            //TODO - podmínky pro střelbu
            string result = " ";
            
            if (navyBattlePieceId == null) return result;
            NavyBattlePiece battlePiece = _db.NavyBattlePieces.Include(x => x.UserGame).Where(p => p.Id == navyBattlePieceId).SingleOrDefault();
            Game currentgame = GetCurrentGame();
            UserGame activeUserGame = _db.UserGames.Include(x => x.NavyBattlePieces).Where(m => m.UserId == currentgame.PlayerOnTurnId && m.GameId == currentgame.GameId).AsNoTracking().SingleOrDefault();
            string activeUserId = GetActiveUserId();
            UserGame ShootersGame = _db.UserGames.Where(u => u.UserId == activeUserId && u.GameId == currentgame.GameId)
            .Include(u => u.Game)
            .AsNoTracking().SingleOrDefault();

            IList<NavyBattlePiece> UnhittedPieces = _db.NavyBattlePieces.Where(u => u.UserGameId == battlePiece.UserGameId && u.PieceState == PieceState.Ship).ToList();
            User hittedPlayer = _db.Users.Where(u => u.Id == activeUserId).Where(u => u.Id == battlePiece.UserGame.UserId).FirstOrDefault();
            if (UnhittedPieces.Count() < 1)
            {
                //result = $"Zničil jsi poslední loď {hittedPlayer.UserName}";
                //hittedPlayer. = PlayerState.Loser;
                //_db.Users.Update(hittedPlayer);
                currentgame.GameState = GameState.End;
                //_db.Games.Update(ShootersGame.Game);
                //_db.SaveChanges();
            }

            //foreach (var piece in activeUserGame.NavyBattlePieces)
            //{
            //    if (piece.PieceState == PieceState.Ship)
            //    {
            //        int ShipCount = 0;
            //        ShipCount++;
            //        if (ShipCount == 0)
            //        {
            //            currentgame.GameState = GameState.End;
            //        }
            //    }
            //}

            if (currentgame.GameState == GameState.End)
            {
                currentgame.GameState = GameState.End;
                _db.SaveChanges();
                return "Konec hry!";
            }
            else
            {
                currentgame.GameState = GameState.Battle;
                _db.SaveChanges();
                if (battlePiece.UserGameId == ShootersGame.Id)
                {
                    return "Nemůžeš střílet do své lodě";
                }
                if (battlePiece.PieceState == PieceState.DeadShip)
                {
                    return "Tato loď je již trefená";
                }
                if (battlePiece.PieceState == PieceState.DeadWater)
                {
                    return "Tuto vodu jsi již trefil";
                }
                else 
                {
                    PieceState newState;
                    switch (battlePiece.PieceState)
                    {
                        case PieceState.Ship:
                            newState = PieceState.DeadShip;
                            battlePiece.Hidden = false;
                            result = "Trefil jsi loď!";
               
                            break;
                        case PieceState.Water:
                            newState = PieceState.DeadWater;
                            battlePiece.Hidden = false;
                            result = "Trefil jsi vodu";
                            
                            break;
                        default:
                            newState = battlePiece.PieceState;
                            battlePiece.Hidden = false;
                            break;
                    }
                    battlePiece.PieceState = newState;
                    _db.SaveChanges();
                }
            }

            return result;
        }

        //public void ContinueGame(UserGame user)
        //{
        //    int Round = 0;
        //    Round++;
        //    List<UserGame> userGames = _db.UserGames.Where(u => u.GameId == user.Game.GameId).OrderBy(u => u.Id).ToList();
        //    UserGame nextPlayer = new UserGame();
        //    int index = userGames.FindIndex(u => u.Id == user.Id);
        //    if (Round == 1)
        //    {
        //        nextPlayer = userGames[index++];
        //    }
        //    else
        //    {
        //        nextPlayer = userGames[0];
        //    }
        //    user.Game.PlayerOnTurnId = nextPlayer.UserId;
        //    Round = 0;
        //    _db.Games.Update(user.Game);
        //}

        public void PlaceShips(int? navyBattlePieceId)
        {
            if (navyBattlePieceId == null) return;
            NavyBattlePiece battlePiece = _db.NavyBattlePieces.Where(p => p.Id == navyBattlePieceId).SingleOrDefault();

            Game currentgame = GetCurrentGame();
            UserGame activeUserGame = _db.UserGames.Where(m => m.UserId == currentgame.PlayerOnTurnId && m.GameId == currentgame.GameId).AsNoTracking().SingleOrDefault();

            string activeUserId = GetActiveUserId();
            UserGame ShootersGame = _db.UserGames.Where(u => u.UserId == activeUserId && u.GameId == currentgame.GameId)
            .Include(u => u.Game)
            .AsNoTracking().SingleOrDefault();

            PieceState newState;
            switch (battlePiece.PieceState)
            {
                case PieceState.Ship:
                    newState = PieceState.Water;
                    battlePiece.Hidden = true;
                    break;
                case PieceState.Water:
                    newState = PieceState.Ship;
                    battlePiece.Hidden = true;
                    break;
                default:
                    newState = battlePiece.PieceState;
                    break;
            }
            battlePiece.PieceState = newState;
            _db.SaveChanges();
        }

        public List<NavyBattlePiece> GetNavyBattlePieces(int userGameId)
        {
            var pieces = _db.NavyBattlePieces.Where(g => g.UserGameId == userGameId).ToList();
            return pieces;
        }

        public Game GetCurrentGame()
        {
            Guid currentGameId = CurrentGameId;
            return _db.Games.Where(x => x.GameId == currentGameId).Include(u => u.UserGames).ThenInclude(u => u.User).AsNoTracking().SingleOrDefault();
        }

        public string GetActiveUserId()
        {
            var output = _http.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return output;
        }
        public string GetActiveUserMail()
        {
            var output = _http.HttpContext.User.FindFirstValue(ClaimTypes.Email);
            return output;
        }
        public IList<NavyBattlePiece> GetBoard()
        {
            var ug = GetUserGame();
            var output = _db.NavyBattlePieces.Where(u => u.UserGameId == ug.Id).ToList();
            return output;
        }
        public UserGame GetUserGame()
        {
            var Id = GetActiveUserId();
            var output = _db.UserGames.Where(u => u.UserId == Id && u.GameId == CurrentGameId).AsNoTracking().FirstOrDefault();
            return output;
        }
        public IList<UserGame> GetUserGames()
        {
            Guid gameId = CurrentGameId;
            return _db.UserGames.Where(g => g.GameId == CurrentGameId).Include(u => u.User).Include(g => g.Game).ToList();
        }
        public string GetUserName(string userId)
        {
            return _db.Users.SingleOrDefault(u => u.Id == userId).UserName;
        }
        public void CreateBattleField(UserGame userGame)
        {
            var game = _db.Games.SingleOrDefault(x => x.GameId == userGame.GameId);

            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    _db.NavyBattlePieces.Add(new NavyBattlePiece { UserGame = userGame, ShipId = 1, PosX = x, PosY = y, Hidden = true });
                }
            }
            _db.SaveChanges();
        }
        public void StartGame()
        {
            Game game = new Game
            {
                GameId = Guid.NewGuid(),
                MaxPlayers = 2,
                OwnerId = _user,
                PlayerOnTurnId = _user,
                GameState = GameState.Setup
            };
            UserGame userGame = new UserGame
            {
                GameId = game.GameId,
                UserId = _user,
            };
            SaveGame("Game", game.GameId);
            _db.Games.Add(game);
            _db.UserGames.Add(userGame);
            CreateBattleField(userGame);
            _db.SaveChanges();
        }
        public void JoinGame(Guid gameId)
        {
            var userGames = GetUserGame(); 
            if(userGames is null)
            {
                UserGame userGame = new UserGame
                {
                    GameId = gameId,
                    UserId = _user,
                };
                SaveGame("Game", gameId);
                _db.UserGames.Add(userGame);
                CreateBattleField(userGame);
                _db.SaveChanges();
            }  
        }
    }
}
