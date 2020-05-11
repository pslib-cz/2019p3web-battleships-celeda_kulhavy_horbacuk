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

        public List<Game> GetGames()
        { 
            return _db.Games.ToList();
        }

        public List<User> GetUsers()
        {
            return _db.Users.ToList();
        }

        public void RemoveGame(Guid gameId)
        {
            var game = _db.Games.SingleOrDefault(c => c.GameId == gameId);
            _db.Games.Remove(game);
            _db.SaveChanges();
        }

        public bool RemoveUserFromGame(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
