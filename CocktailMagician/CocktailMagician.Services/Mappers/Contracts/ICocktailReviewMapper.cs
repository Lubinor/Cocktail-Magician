using CocktailMagician.Models;
using CocktailMagician.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Services.Mappers.Contracts
{
    public interface ICocktailReviewMapper
    {
        public CocktailReviewDTO MapToCocktailReviewDTO(CocktailsUsersReviews review);
        public CocktailsUsersReviews MapToCocktailReview(CocktailReviewDTO reviewDTO);
    }
}
