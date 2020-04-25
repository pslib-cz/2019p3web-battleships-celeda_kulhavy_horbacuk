using BattleShips.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Services
{
    public interface ISetup
    {
        //Vytvařeni a rozmištěni vlastnich lodi na sve herni ploše
        public InGame GetGame(int id);
        public UserGame GetUserGame(string userId, int gameId);
        public void ShipsReady(); //Rozmistěni lodi na herni plochu
        public void Ready(); //Konrola jestli všichni už jsou připraveny ke hře
        public string AddShipColorManagement(int navyBattlePieceId);
        //public void AddShip();    // Přidavani vlastni lodi na plochu
        //public void MarginToWater();  // Změna prazdnych poliček(battlepiecu) na vodu
        public ShipGame CreateShipGame(int shipid, Guid gameid);
        public bool AddShipGame(ShipGame shipGame);
        public bool AddShipGame(int shipid, Guid gameid);
        public List<Ship> GetShips();
    }
}
