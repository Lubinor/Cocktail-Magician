﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Web.Models
{
    public class EditCocktailViewModel
    {
        public EditCocktailViewModel()
        {

        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public ICollection<int> ContainedIngredients { get; set; }
        public ICollection<int> ContainedBars { get; set; }
        [Required]
        public IFormFile File { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageSource { get; set; }
    }
}
