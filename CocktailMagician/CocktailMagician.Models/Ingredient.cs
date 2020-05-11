using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<IngredientsCocktails> Cocktails { get; set; } = new HashSet<IngredientsCocktails>();
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; }
    }
}
