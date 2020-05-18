using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Services.DTOs
{
    public class CocktailDTO
    {
        public CocktailDTO()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public double AverageRating { get; set; }
        public ICollection<IngredientDTO> Ingredients { get; set; }
        public ICollection<BarDTO> Bars { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
