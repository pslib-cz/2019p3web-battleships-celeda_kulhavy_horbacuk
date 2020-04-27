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
        List<User> GetUsers();
        List<Game> GetGames();
        List<Game> GetGameDetails(Guid gameId);
        bool RemoveGame(Guid Id);
        bool AddGame(Game Game);
        bool AddUser(User user);
        bool RemoveUserFromGame(string userId);
        UserGame CreateNewGame(string userId, Guid gameId);
        void UserCreateGame(Guid gameId);
        User CreateNewUser(string userId, string Name);
    }
}
