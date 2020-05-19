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

namespace BattleShips.Pages.Game
{
    public class InGameModel : PageModel
    {
        public ISetup _isetup;
        public IGame _igame;

        public Model.Game Games;
        public ApplicationDbContext _db;
        public GameBoardModel _gbm;

        public Guid _gameId;
        public IList<UserGame> UserGames { get; set; }
        public IList<GameBoardModel> GameBoardModels { get; set; } = new List<GameBoardModel>();
        public InGameModel(ISetup isetup, IGame igame, ApplicationDbContext db)
        {
            _isetup = isetup;
            _igame = igame;
            _db = db;
            _gameId = _igame.LoadGame("Game");
        }

        public void OnGet()
        {
            Games = _igame.GetCurrentGame();
            UserGames = _igame.GetUserGames();
            for (int board = 0; board < UserGames.Count(); board++)
            {
                IList<NavyBattlePiece> navyBattlePieces = _igame.GetNavyBattlePieces(UserGames[board].Id);
                GameBoardModel newBoard = new GameBoardModel(navyBattlePieces, UserGames[board], _igame.GetActiveUserId());
                GameBoardModels.Add(newBoard);
            }
        }

        public ActionResult OnGetFireClick(int Id)
        {
            _igame.Fire(Id);
            return RedirectToPage("./InGame");
        }
    }
}