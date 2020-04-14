using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BattleShips.Model;
using BattleShips.Services;
using BattleShips.ViewModel;

namespace BattleShips
{
    public class CreateGameModel : PageModel 
    {
        public ApplicationDbContext _db;
        public ISetup _isetup;

        [BindProperty]
        public ShipViewModel Ship { get; set; }
        public List<Ship>Ships { get; set; }
        

        public CreateGameModel(ApplicationDbContext db, ISetup isetup)
        {
            _db = db;
            _isetup = isetup;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            _isetup.AddShipGame(new ShipGame() { ShipId = Ship.Id, GameId = });
            return RedirectToPage("./ShipPlacement");
        }
    }
}