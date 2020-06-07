using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CocktailMagician.Web.Models
{
    [Serializable]
    public class BarViewModel
    {
        public BarViewModel()
        {

        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int CityId { get; set; }
        [DisplayName("City")]
        public string CityName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        [DisplayName("Average Rating")]
        public double AverageRating { get; set; }
        public ICollection<CocktailViewModel> Cocktails { get; set; } = new List<CocktailViewModel>();
        [DisplayName("Cocktails")]
        public string CocktailNames { get; set; }
        [Required]
        public IFormFile File { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageSource { get; set; }


    }
}
