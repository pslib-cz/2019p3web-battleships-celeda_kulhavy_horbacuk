using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BattleShips.ViewModel;
using BattleShips.Model;
using BattleShips.Services;
using Microsoft.AspNetCore.Authorization;

namespace BattleShips
{
    [Authorize]
    public class GameListModel : PageModel
    {
        IManagement _management;
        IGame _game;
        public GameListModel(IManagement management, IGame game)
        {
            _management = management;
            _game = game;
            GameLists = new List<GameListView>();
        }
        [BindProperty(SupportsGet = true)]
        public Guid gameId { get; set; }
        public List<Game> Games { get; set; }
        public List<User> Users { get; set; }
        public List<GameListView> GameLists { get; set; }
        public string UserId { get; set; }
        public void OnGet()
        {
            Games = new List<Game>();
            Games = _management.GetGames();
            Users = new List<User>();
            Users = _management.GetUsers();
            UserId = _game.GetActiveUserId();
        }
        public IActionResult OnGetRemove(Guid id)
        {
            _management.RemoveGame(id);
            return RedirectToPage("./GameList");
        }
        public IActionResult OnPostJoinGameOnPlacement(Guid id)
        {
            _game.SaveGame("Game", id);
            return RedirectToPage("./ShipPlacement");
            //UserGame
        }
        public IActionResult OnPostStartGame(Guid id)
        {
            _game.SaveGame("Game", id);
            return RedirectToPage("./InGame");
        }
    }
}