using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Models
{
    public class BarsCocktails
    {
        public int BarId { get; set; }
        public int CocktailId { get; set; }

        public Bar Bar { get; set; }
        public Cocktail Cocktail { get; set; }
    }
}
