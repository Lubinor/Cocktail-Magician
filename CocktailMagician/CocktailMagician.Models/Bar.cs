using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CocktailMagician.Models
{
    public class Bar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public double AverageRating { get; set; }
        public ICollection<BarsCocktails> Cocktails { get; set; } = new HashSet<BarsCocktails>();
        public ICollection<BarsUsersReviews> Reviews { get; set; } = new HashSet<BarsUsersReviews>();
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; }
    }
}
