using System;
using System.ComponentModel.DataAnnotations;

namespace CocktailMagician.Models
{
    public class BarsUsersReviews
    {
        public int BarId { get; set; }
        public int UserId { get; set; }

        public Bar Bar { get; set; }
        public User User { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
        public DateTime? CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
