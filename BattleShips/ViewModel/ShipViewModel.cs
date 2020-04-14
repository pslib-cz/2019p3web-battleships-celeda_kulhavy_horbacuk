using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BattleShips.ViewModel
{
    public class ShipViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Počet lodí")]
        public int Count { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Jméno lodi")]
        public string Name { get; set; }
    }
}
