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

        public GameBoardModel _gbm;
        public DbSet<Model.Game> Games;
        public ApplicationDbContext _db;

        public IList<UserGame> UserGames { get; set; }
        public IList<GameBoardModel> GameBoardModels { get; set; } = new List<GameBoardModel>();
        public InGameModel(ISetup isetup, ApplicationDbContext db, GameBoardModel gbm)
        {
            _gbm = gbm;
            _isetup = isetup;
            _db = db;
        }

        public void OnGet()
        {
            UserGames = _igame.GetUserGames();
            IList<NavyBattlePiece> navyBattlePieces = _igame.GetNavyBattlePieces(/*UserGame.Id*/);
            GameBoardModel gameBoard = new GameBoardModel(navyBattlePieces);
            GameBoardModels.Add(gameBoard);
        }
    }
}