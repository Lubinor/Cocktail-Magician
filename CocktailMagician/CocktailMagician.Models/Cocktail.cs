using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Models
{
    public class Cocktail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double AverageRating { get; set; }
        public ICollection<IngredientsCocktails> Ingredients { get; set; } = new HashSet<IngredientsCocktails>();
        public ICollection<BarsCocktails> Bars { get; set; } = new HashSet<BarsCocktails>();
        public ICollection<CocktailsUsersReviews> Reviews { get; set; } = new HashSet<CocktailsUsersReviews>();
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; }
    }
}
