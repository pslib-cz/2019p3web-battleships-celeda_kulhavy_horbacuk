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
        public string Color { get; set; }
        public GameBoardModel _gbm;
        public DbSet<Game> Games;
        public ApplicationDbContext _db;

        public IEnumerable<IGrouping<int, NavyBattlePiece>> battlePieces;
        public ShipPlacementModel(ISetup isetup, ApplicationDbContext db, GameBoardModel gbm)
        {
            _gbm = gbm;
            _isetup = isetup;
            _db = db;
            Color = "deepskyblue"; // asi tu ma byt spiš nějaky foreach ktery projde každy poličko (navybattlepiece) a vzhledem k hodnotě vlastnosti PieceState kdaždemu poličku se načte barva
        }
        public void OnGet()
        {
            //battlePieces = _gbm.GameBoard(navyBattlePieces);
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