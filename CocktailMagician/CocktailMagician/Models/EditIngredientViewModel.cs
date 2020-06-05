﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Web.Models
{
    public class EditIngredientViewModel
    {
        public EditIngredientViewModel()
        {

        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        //public ICollection<int> ContainedCocktails { get; set; }
    }
}