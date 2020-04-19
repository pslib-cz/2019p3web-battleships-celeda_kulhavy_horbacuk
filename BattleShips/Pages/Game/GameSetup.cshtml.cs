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
    public class GameSetupModel : PageModel 
    {
        public ApplicationDbContext _db;
        public ISetup _isetup;
        public IManagement _management;

        [BindProperty]
        public ShipViewModel Ship { get; set; }
        public List<Ship>Ships { get; set; }
        
        public int boardSize { get; set; }

        public GameSetupModel(ApplicationDbContext db, ISetup isetup)
        {
            _db = db;
            _isetup = isetup;
        }

        public void OnGet()
        {
            //_management.UserCreateGame(new UserGame() { UserId = User.Identity.Name, GameId =  });
            Ships = new List<Ship>();
            Ships = _isetup.GetShips();

        }

        public IActionResult OnPost()
        {
            //Guid gameId = Guid.NewGuid();
            //_isetup.AddShipGame(new ShipGame() { ShipId = Ship.Id, GameId = gameId });
            //_management.CreateNewGame(new Game() { OwnerId = User.Identity.Name, GameId = gameId, GameSize = boardSize });
            return RedirectToPage("./ShipPlacement");
        }
    }
}