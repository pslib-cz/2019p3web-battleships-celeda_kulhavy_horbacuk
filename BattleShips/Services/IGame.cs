using BattleShips.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Services
{
    public interface IGame
    {
        IEnumerable<User> GetAllUsers();
        int Size { get; set; }
        int Players { get; set; }
        bool RemoveGame(Guid Id);
        bool AddGame(Game Game);
        //AddUser
        //ShipPlacement       
    }
}
