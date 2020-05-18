using CocktailMagician.Models;
using CocktailMagician.Services.DTOs;
using CocktailMagician.Services.Mappers.Contracts;

namespace CocktailMagician.Services.Mappers
{
    public class BarReviewMapper : IBarReviewMapper
    {
        public BarReviewDTO BarReviewToBarReviewDTO(BarsUsersReviews review)
        {
            BarReviewDTO reviewDTO = new BarReviewDTO
            {
                Rating = review.Rating,
                Comment = review.Comment,
                CreatedOn = review.CreatedOn,
                IsDeleted = review.IsDeleted,
                BarId = review.BarId,
                AuthorId = review.UserId,
                BarName = review.Bar.Name,
                Author = review.User.UserName
            };

            return reviewDTO;
        }
        public BarsUsersReviews BarReviewDTOtoBarReview(BarReviewDTO reviewDTO)
        {
            BarsUsersReviews review = new BarsUsersReviews
            {
                Rating = reviewDTO.Rating,
                Comment = reviewDTO.Comment,
                CreatedOn = reviewDTO.CreatedOn,
                IsDeleted = reviewDTO.IsDeleted,
                BarId = reviewDTO.BarId,
                UserId = reviewDTO.AuthorId
            };

            return review;
        }
    }
}
