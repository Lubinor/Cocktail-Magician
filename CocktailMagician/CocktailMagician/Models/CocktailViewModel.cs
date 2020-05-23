using System.Collections.Generic;

namespace CocktailMagician.Web.Models
{
    public class CocktailViewModel
    {
        public CocktailViewModel()
        {

        }
        public string Name { get; set; }
        public double AverageRating { get; set; }
        public ICollection<IngredientViewModel> Ingredients { get; set; } = new List<IngredientViewModel>();
        public ICollection<BarViewModel> Bars { get; set; } = new List<BarViewModel>();
    }
}
