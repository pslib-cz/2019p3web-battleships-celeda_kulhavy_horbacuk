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

namespace BattleShips
{
    public class ShipPlacementModel : PageModel
    {
        public ISetup _isetup;
        public IGame _igame;

        public Game Games;
        public ApplicationDbContext _db;
        public UserGame UserGame;
        public GameBoardModel GameBoard;

        public Guid _gameId;
        public IList<UserGame> UserGames { get; set; }
        public IList<NavyBattlePiece> navyBattlePieces { get; set; }
        public IList<GameBoardModel> GameBoardModels { get; set; } = new List<GameBoardModel>();

        public ShipPlacementModel(ISetup isetup, ApplicationDbContext db, IGame igame)
        {
            _isetup = isetup;
            _db = db;
            _igame = igame;
            _gameId = _igame.LoadGame("Game");
        }
        public void OnGet()
        {
            Games = _igame.GetCurrentGame();
            UserGame = _igame.GetUserGame();
            navyBattlePieces = _igame.GetBoard();
            //IList<NavyBattlePiece> navyBattlePieces = _igame.GetNavyBattlePieces(UserGames);
            //    GameBoardModel newBoard = new GameBoardModel(navyBattlePieces, UserGame/*[board]*/);
            //    GameBoardModels.Add(newBoard);
            GameBoard = new GameBoardModel(navyBattlePieces, UserGame);
        }
        public ActionResult OnGetPlaceShips(int Id)
        {
            _igame.PlaceShips(Id);
            return RedirectToPage("./ShipPlacement");
        }

        public IActionResult OnGetStart()
        {
            _igame.SaveGame("Game", _gameId);
            return RedirectToPage("./InGame");
        }
    }
}