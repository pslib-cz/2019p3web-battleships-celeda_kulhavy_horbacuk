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

        public GameBoardModel _gbm;
        public DbSet<Game> Games;
        public ApplicationDbContext _db;

        public IList<UserGame> UserGames { get; set; }
        public IList<GameBoardModel> GameBoardModels { get; set; } = new List<GameBoardModel>();

        public ShipPlacementModel(ISetup isetup, ApplicationDbContext db, GameBoardModel gbm)
        {
            _gbm = gbm;
            _isetup = isetup;
            _db = db;
            //Color = "deepskyblue"; // asi tu ma byt spiš nějaky foreach ktery projde každy poličko (navybattlepiece) a vzhledem k hodnotě vlastnosti PieceState kdaždemu poličku se načte barva
        }
        public void OnGet()
        {
            UserGames = _igame.GetUserGames();
            IList<NavyBattlePiece> navyBattlePieces = _igame.GetNavyBattlePieces(/*UserGames.Id*/);
            GameBoardModel gameBoard = new GameBoardModel(navyBattlePieces);
            GameBoardModels.Add(gameBoard);
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