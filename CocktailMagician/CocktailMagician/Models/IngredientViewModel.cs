using System.Collections.Generic;

namespace CocktailMagician.Web.Models
{
    public class IngredientViewModel
    {
        public IngredientViewModel()
        {

        }
        public string Name { get; set; }
        public ICollection<CocktailViewModel> Cocktails { get; set; } = new List<CocktailViewModel>();
    }
}
