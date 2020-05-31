using System;
using System.Collections.Generic;
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
        public string Name { get; set; }
        public string OldName { get; set; }
        public ICollection<BarViewModel> Bars { get; set; } = new List<BarViewModel>();
    }
}
