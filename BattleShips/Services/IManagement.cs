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
        IEnumerable<User> GetAllUsers();
        IEnumerable<Game> GetGames();
        bool RemoveGame(Guid Id);
        bool AddGame(Game Game);
    }
}
