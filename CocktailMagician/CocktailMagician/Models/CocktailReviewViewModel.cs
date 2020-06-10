using System;
using System.ComponentModel.DataAnnotations;

namespace CocktailMagician.Web.Models
{
    public class CocktailReviewViewModel
    {
        public CocktailReviewViewModel()
        {

        }
        [Required]
        [Range(0, 5, ErrorMessage = "Raitig is between 0-5")]
        public double Rating { get; set; }

        [MaxLength(500, ErrorMessage = "Use maximum 500 chars for your comment")]
        public string Comment { get; set; }
        public int CocktailId { get; set; }
        public string CocktailName { get; set; }
        public int AuthorId { get; set; }
        public string Author { get; set; }
    }
}
