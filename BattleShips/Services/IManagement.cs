using BattleShips.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Services
{
    public interface IManagement
    {
        //vytvoreni novy hry, prihlasovani, vypis, odhlasovani, hlavni stranka 
        //Kulhavý
        IEnumerable<User> GetUsers(string userId);
        IEnumerable<Game> GetGames(Guid gameId);
        IEnumerable<Game> GetGames(int? gameFilter);
        List<Game> GetGameDetails(Guid gameId);
        bool RemoveGame(Guid Id);
        bool AddGame(Game Game);
        bool AddUser(User user);
        bool RemoveUserFromGame(string userId);
        Game CreateNewGame(string userId, Guid gameId, int maxPlayers, int boardSize);
        User CreateNewUser(string userId, string Name);
        UserGame CreateUserGame(string userId, Guid gameId);
    }
}
