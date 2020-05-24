using BattleShips.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.Services
{
    public interface IGame
    {
        public string Fire(int? navyBattlePieceId);
        public void PlaceShips(int? navyBattlePieceId);
        public Guid LoadGame(string id);
        public void SaveGame(string id, Guid guid);
        List<NavyBattlePiece> GetNavyBattlePieces(int userGameId);
        public string GetActiveUserId();
        public string GetActiveUserMail();
        public string GetUserName(string userId);
        public Game GetCurrentGame();
        IList<UserGame> GetUserGames();
        void StartGame();
        void CreateBattleField(UserGame userGame);
        void JoinGame(Guid gameId);
        UserGame GetUserGame();
        IList<NavyBattlePiece> GetBoard();
    }
}
