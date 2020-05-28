using CocktailMagician.Models;
using CocktailMagician.Services.DTOs;
using CocktailMagician.Services.Mappers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Services.Mappers
{
    public class CocktailReviewMapper : ICocktailReviewMapper
    {
        public CocktailReviewDTO MapToCocktailReviewDTO(CocktailsUsersReviews review)
        {
            CocktailReviewDTO reviewDTO = new CocktailReviewDTO
            {
                Rating = review.Rating,
                Comment = review.Comment,
                CocktailId = review.CocktailId,
                AuthorId = review.UserId,
                CocktailName = review.Cocktail.Name,
                Author = review.User.UserName
            };

            return reviewDTO;
        }

        public CocktailsUsersReviews MapToCocktailReview(CocktailReviewDTO reviewDTO)
        {
            CocktailsUsersReviews review = new CocktailsUsersReviews
            {
                Rating = reviewDTO.Rating,
                Comment = reviewDTO.Comment,
                CocktailId = reviewDTO.CocktailId,
                UserId = reviewDTO.AuthorId
            };

            return review;
        }

    }
}
