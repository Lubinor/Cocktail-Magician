using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CocktailMagician.Web.Models
{
    public class IngredientViewModel
    {
        public IngredientViewModel()
        {

        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string CocktailNames { get; set; }
        public ICollection<CocktailViewModel> Cocktails { get; set; } = new List<CocktailViewModel>();
    }
}
