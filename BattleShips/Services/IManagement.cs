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
        bool RemoveGame(Guid Id);
        bool RemoveUserFromGame(string userId);
        bool CreateNewGame(Guid gameId);
        void UserCreateGame(Guid gameId);
    }
}
