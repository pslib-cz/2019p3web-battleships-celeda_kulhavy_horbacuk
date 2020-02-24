using BattleShips.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Services
{
    public interface IGame
    {
        int Size { get; set; }
        int Players { get; set; }
        
        //AddUser
        //ShipPlacement       
    }
}
