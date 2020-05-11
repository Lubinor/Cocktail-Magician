﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Models
{
    public class IngredientsCocktails
    {
        public int IngredientId { get; set; }
        public int CocktailId { get; set; }

        public Ingredient Ingredient { get; set; }
        public Cocktail Cocktail { get; set; }
    }
}
