using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CocktailMagician.Web.Models
{
    public class CocktailViewModel
    {
        public CocktailViewModel()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public double AverageRating { get; set; }
        public ICollection<IngredientViewModel> Ingredients { get; set; } = new List<IngredientViewModel>();
        public ICollection<BarViewModel> Bars { get; set; } = new List<BarViewModel>();
        public string IngredientNames { get; set; }
        public string BarNames { get; set; }
    }
}
