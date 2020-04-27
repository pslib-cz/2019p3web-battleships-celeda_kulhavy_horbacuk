using BattleShips.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Services
{
    public class Management : IManagement
    {
        public ApplicationDbContext _db;
        public Identity _identity;

        public Management(ApplicationDbContext db, Identity identity)
        {
            _db = db;
            _identity = identity;
        }


        public bool AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool CreateNewGame(string userId, Guid gameId, int gameSize = 10)
        {
            Guid newGameId = Guid.NewGuid();
            var game = new Game() { OwnerId = userId, GameId = newGameId, GameSize = gameSize };
            _db.Games.Add(game);
            _db.SaveChanges();
            return true;
        }

        public void UserCreateGame(Guid gameId) //TODO navybattlepiece
        {
            Guid guid = Guid.NewGuid();
            var usergame = new UserGame { UserId = _identity.LoginId, GameId = guid };
            _db.UserGames.Add(usergame);
            _db.SaveChanges();
        }

        public User CreateNewUser(string userId, string Name)
        {
            throw new NotImplementedException();
        }


        public List<InGame> GetGameDetails(Guid gameId)
        {
            throw new NotImplementedException();
        }

        public List<Game> GetGames()
        { 
            return _db.Games.ToList();
        }

        public List<User> GetUsers()
        {
            return _db.Users.ToList();
        }

        public bool RemoveGame(Guid Id)
        {
            var trida = _db.Games.SingleOrDefault(c => c.GameId == Id);
            _db.Games.Remove(trida);
            _db.SaveChanges();
            return true;
        }

        public bool RemoveUserFromGame(string userId)
        {
            throw new NotImplementedException();
        }

        List<Game> IManagement.GetGameDetails(Guid gameId)
        {
            throw new NotImplementedException();
        }

        public bool AddGame(Game Game)
        {
            throw new NotImplementedException();
        }

        UserGame IManagement.CreateNewGame(string userId, Guid gameId)
        {
            throw new NotImplementedException();
        }
    }
}
