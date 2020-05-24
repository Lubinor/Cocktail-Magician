using System.Collections.Generic;

namespace CocktailMagician.Web.Models
{
    public class IngredientViewModel
    {
        public IngredientViewModel()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CocktailViewModel> Cocktails { get; set; } = new List<CocktailViewModel>();
    }
}
