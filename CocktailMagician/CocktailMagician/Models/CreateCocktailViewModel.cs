using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Web.Models
{
    public class CreateCocktailViewModel
    {
        public CreateCocktailViewModel()
        {

        }
        [Required]
        public string Name { get; set; }
        public ICollection<int> ContainedIngredients { get; set; }
    }
}
