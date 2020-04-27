using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleShips.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BattleShips.Pages.Game
{
    public class InGameModel : PageModel
    {
        public string Color { get; set; }
        public ApplicationDbContext _db;
        public InGameModel(ApplicationDbContext db)
        {
            _db = db;
            Color = "black";
        }

        public void OnGet()
        {

        }
    }
}