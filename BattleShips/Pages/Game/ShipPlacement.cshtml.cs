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

        public DbSet<Game> Games;
        public ApplicationDbContext _db;

        public IList<UserGame> UserGames { get; set; }

        public ShipPlacementModel(ISetup isetup, ApplicationDbContext db)
        {
            _isetup = isetup;
            _db = db;
        }
        public void OnGet()
        {
            
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