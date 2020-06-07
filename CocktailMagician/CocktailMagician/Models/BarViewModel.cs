using System;
using System.Collections.Generic;

namespace CocktailMagician.Web.Models
{
    [Serializable]
    public class BarViewModel
    {
        public BarViewModel()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public double AverageRating { get; set; }
        public ICollection<CocktailViewModel> Cocktails { get; set; } = new List<CocktailViewModel>();
        public string CocktailNames { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageSource { get; set; }


    }
}
