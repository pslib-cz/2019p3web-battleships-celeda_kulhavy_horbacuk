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
        public Management(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool AddGame(Game Game)
        {
            _db.Games.Add(Game);
            _db.SaveChanges();
            return true;
        }

        public bool AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public Game CreateNewGame(string userId, Guid gameId, int maxPlayers, int boardSize)
        {
            Guid newGameId = Guid.NewGuid();
            return new Game() { OwnerId = userId, GameId = newGameId, MaxPlayers = maxPlayers, GameSize = boardSize };
        }

        public User CreateNewUser(string userId, string Name)
        {
            throw new NotImplementedException();
        }

        public UserGame CreateUserGame(string userId, Guid gameId)
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
    }
}
