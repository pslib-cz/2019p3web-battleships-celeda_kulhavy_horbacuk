using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BattleShips.Model;
using BattleShips.Services;

namespace BattleShips
{
    public class CreateGameModel : PageModel 
    {
        public ApplicationDbContext _db;
        public ISetup _isetup;
        public List<Ship>Ships { get; set; }
        

        public CreateGameModel(ApplicationDbContext db, ISetup isetup)
        {
            _db = db;
            _isetup = isetup;

        }

        public void OnGet()
        {

        }

        //public IActionResult OnPost()
        //{
        //    _isetup.AddShip(new Ship() { 
        //        });
        //}
    }
}