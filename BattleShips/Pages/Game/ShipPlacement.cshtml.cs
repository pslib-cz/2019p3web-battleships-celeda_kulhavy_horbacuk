using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleShips.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BattleShips
{
    public class ShipPlacementModel : PageModel
    {
        public InGame _ingame;
        public ShipPlacementModel(InGame ingame)
        {
            _ingame = ingame;
            Color = "blue";
        }

        public string Color { get; set; }
        public void OnGet()
        {

            var user = this.HttpContext.User
                .FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "";
            var user2 = this.HttpContext.User
                .FindFirst(System.Security.Claims.ClaimTypes.Anonymous)?.Value ?? "";
        }
        public void OnGetAddShip()
        { 
            
        }
    }
}