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
        public ISetup _isetup;
        public string Color { get; set; }
        public ShipPlacementModel(ISetup isetup)
        {
            _isetup = isetup;
            Color = "deepskyblue";
        }
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