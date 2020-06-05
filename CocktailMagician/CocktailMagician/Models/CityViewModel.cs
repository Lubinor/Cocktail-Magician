using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Web.Models
{
    public class CityViewModel
    {
        public CityViewModel()
        {

        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string OldName { get; set; }
        public ICollection<BarViewModel> Bars { get; set; } = new List<BarViewModel>();
        public string BarNames { get; set; }
    }
}
