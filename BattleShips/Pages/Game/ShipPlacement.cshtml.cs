using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleShips.Model;
using BattleShips.Services;
using BattleShips.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BattleShips
{
    public class ShipPlacementModel : PageModel
    {
        public ISetup _isetup;
        public IGame _igame;

        public Game Games;
        public ApplicationDbContext _db;

        public Guid _gameId;
        public IList<UserGame> UserGames { get; set; }
        public IList<GameBoardModel> GameBoardModels { get; set; } = new List<GameBoardModel>();

        public ShipPlacementModel(ISetup isetup, ApplicationDbContext db, IGame igame)
        {
            _isetup = isetup;
            _db = db;
            _igame = igame;
            _gameId = _igame.LoadGame("Game");
        }
        public void OnGet()
        {
            Games = _igame.GetCurrentGame();
            UserGames = _igame.GetUserGames(_gameId);
            for (int board = 0; board < UserGames.Count(); board++)
            {
                IList<NavyBattlePiece> navyBattlePieces = _igame.GetNavyBattlePieces(UserGames[board].Id);
                GameBoardModel newBoard = new GameBoardModel(navyBattlePieces, UserGames[board]);
                GameBoardModels.Add(newBoard);
            }
        }
        public void OnGetAddShip()
        {
            //_isetup.AddShip();
        }

        public IActionResult OnGetStart()
        {
            //Ještě se zde rozmistěne lodě museji uložit do databaze nebo sessionu asi

            //_isetup.MatginToWater();
            return RedirectToPage("./InGame");
        }
    }
}