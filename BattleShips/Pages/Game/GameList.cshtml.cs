using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BattleShips.ViewModel;
using BattleShips.Model;
using BattleShips.Services;

namespace BattleShips
{
    public class GameListModel : PageModel
    {
        IManagement _management;
        public GameListModel(IManagement management)
        {
            _management = management;
            GameLists = new List<GameListView>();
        }
        [BindProperty(SupportsGet = true)]
        public Guid gameId { get; set; }
        public List<Game> Games { get; set; }
        public List<GameListView> GameLists { get; set; }
        public void OnGet()
        {
            Games = new List<Game>();
            Games = _management.GetGames(gameId);
            ////příklad
            //var user = this.HttpContext.User
            //    .FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "";
            //var user2 = this.HttpContext.User
            //    .FindFirst(System.Security.Claims.ClaimTypes.Anonymous)?.Value ?? "";
        }
    }
}