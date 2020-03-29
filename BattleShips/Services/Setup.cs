using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleShips.Model;
using BattleShips.Services;

namespace BattleShips.Services
{
    public class Setup : ISetup
    {
        public int HowManyShips { get; set; }
        public List<Ship> AddShip { get; set; }

        public Game GetGame(int id)
        {
            throw new NotImplementedException();
        }

        public UserGame GetUserGame(string userId, int gameId)
        {
            throw new NotImplementedException();
        }

        public void Ready()
        {
            throw new NotImplementedException();
        }

        public void ShipsReady()
        {
            throw new NotImplementedException();
        }
    }
}
