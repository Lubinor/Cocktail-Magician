using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Web.Models
{
    public class ListBarReviewsViewModel
    {
        [DisplayName("All Reviews")]
        public ICollection<BarReviewViewModel> AllBarReviews { get; set; }
        [DisplayName("Comment")]
        public string ReviewComment { get; set; }
        [DisplayName("Author")]
        public string Author { get; set; }
        [DisplayName("Bar")]
        public string Bar { get; set; }
        [DisplayName("Rating")]
        public int Rating { get; set; }
    }
}
