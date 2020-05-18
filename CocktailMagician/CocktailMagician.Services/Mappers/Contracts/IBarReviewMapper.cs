using CocktailMagician.Models;
using CocktailMagician.Services.DTOs;

namespace CocktailMagician.Services.Mappers.Contracts
{
    public interface IBarReviewMapper
    {
        public BarReviewDTO BarReviewToBarReviewDTO(BarsUsersReviews barReview);
        public BarsUsersReviews BarReviewDTOtoBarReview(BarReviewDTO barReviewDTO);
    }
}
