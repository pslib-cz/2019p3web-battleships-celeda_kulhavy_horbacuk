using BattleShips.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Services
{
    public class Management : IManagement
    {
        public bool AddGame(Game Game)
        {
            throw new NotImplementedException();
        }

        public bool AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public Game CreateNewGame(string userId, Guid gameId, int maxPlayers, int boardSize)
        {
            throw new NotImplementedException();
        }

        public User CreateNewUser(string userId, string Name)
        {
            throw new NotImplementedException();
        }

        public UserGame CreateUserGame(string userId, Guid gameId)
        {
            throw new NotImplementedException();
        }

        public List<Game> GetGameDetails(Guid gameId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Game> GetGames(Guid gameId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Game> GetGames(int? gameFilter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsers(string userId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveGame(Guid Id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveUserFromGame(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
