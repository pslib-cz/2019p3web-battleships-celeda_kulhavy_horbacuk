using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.ViewModel
{
    public class GameListView
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Vytvořeno")]
        public string GameCreatedAt { get; set; }
        [Display(Name = "Stav hry")]
        public string GameState { get; set; }
        [Display(Name = "Hráč 1")]
        public string Player1 { get; set; }
        [Display(Name = "Hráč 2")]
        public string Player2 { get; set; }
    }
}
