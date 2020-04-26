using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleShips.Model;
using BattleShips.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BattleShips
{
    public class ShipPlacementModel : PageModel
    {
        public ISetup _isetup;
        public string Color { get; set; }
        public DbSet<Game> Games;
        public ApplicationDbContext _db;
        public ShipPlacementModel(ISetup isetup, ApplicationDbContext db)
        {
            _isetup = isetup;
            _db = db;
            Color = "deepskyblue"; // asi tu ma byt spiš nějaky foreach ktery projde každy poličko (navybattlepiece) a vzhledem k hodnotě vlastnosti PieceState kdaždemu poličku se načte barva
        }
        public void OnGet()
        {
            var user = this.HttpContext.User
                .FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "";
            var user2 = this.HttpContext.User
                .FindFirst(System.Security.Claims.ClaimTypes.Anonymous)?.Value ?? "";
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