using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Web.Models
{
    public class BarReviewViewModel
    {
        public BarReviewViewModel()
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
