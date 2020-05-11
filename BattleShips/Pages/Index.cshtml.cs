using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleShips.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BattleShips.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private IGame _game;

        public IndexModel(ILogger<IndexModel> logger, IGame game)
        {
            _logger = logger;
            _game = game;
        }

        public void OnGet()
        {

        }

        public IActionResult OnGetStart()
        {
            _game.StartGame();
            return RedirectToPage("./Game/GameSetup");
        }
    }
}
