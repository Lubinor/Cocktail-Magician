using System;

namespace CocktailMagician.Services.DTOs
{
    public class BarReviewDTO
    {
        public BarReviewDTO()
        {
           
        }

        public int Rating { get; set; }
        public string Comment { get; set; }
        public int BarId { get; set; }
        public string BarName { get; set; }
        public int AuthorId { get; set; }
        public string Author { get; set; }
    }
}
