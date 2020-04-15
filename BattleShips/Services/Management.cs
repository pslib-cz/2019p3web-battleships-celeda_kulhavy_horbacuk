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

        public bool CreateNewGame(string userId, Guid gameId, int boardSize)
        {
            Guid newGameId = Guid.NewGuid();
            var game = new Game() { OwnerId = userId, GameId = newGameId, GameSize = boardSize };
            _db.Games.Add(game);
            _db.SaveChanges();
            return true;
        }

        public UserGame UserCreateGame(string userId, Guid gameId)
        {
            Guid guid = Guid.NewGuid();
            return new UserGame { UserId = userId, GameId = gameId };
        }

        public User CreateNewUser(string userId, string Name)
        {
            throw new NotImplementedException();
        }


        public List<InGame> GetGameDetails(Guid gameId)
        {
            throw new NotImplementedException();
        }

        public List<Game> GetGames(Guid? gameId)
        {
            IQueryable<Game> games = _db.Games;
            if (gameId != null)
            {
                games = games.Where(i => i.GameId.Equals(gameId));
            }
            return games.ToList();
        }

        public List<User> GetUsers(string userId)
        {
            IQueryable<User> users = _db.Users;
            if (userId != null)
            {
                users = users.Where(i => i.Id.Equals(userId));
            }
            return users.ToList();
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
    }
}
