using Microsoft.VisualBasic;
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
        public ICollection<CocktailDTO> CocktailDTOs { get; set; } = new List<CocktailDTO>();
        //public DateTime? CreatedOn { get; set; }
        //public bool IsDeleted { get; set; } 

        public override bool Equals(object obj)
        {
            var other = (IngredientDTO)obj;
            return this.Name == other.Name; // more props with &&
        }
    }
}
