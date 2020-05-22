using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Services.DTOs
{
    public class IngredientDTO
    {
        public IngredientDTO()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CocktailDTO> Cocktails { get; set; }
    }
}
