﻿using CocktailMagician.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Services.Contracts
{
    public interface ICocktailReviewService
    {
        Task<ICollection<CocktailReviewDTO>> GetAllCocktailReviewsAsync(int cocktailId);
        Task<ICollection<CocktailReviewDTO>> GetAllUserReviewsAsync(int userId);
        Task<CocktailReviewDTO> GetCocktailReviewAsync(int cocktailId, int userId);
        Task<CocktailReviewDTO> CreateCocktailReviewAsync(CocktailReviewDTO cocktailReviewDTO);
        Task<CocktailReviewDTO> UpdateCocktailReviewAsync(int cocktailId, int userId, CocktailReviewDTO cocktailReviewDTO);
        Task<bool> DeleteCocktailReviewAsync(int cocktailId, int userId);
    }
}