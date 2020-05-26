using CocktailMagician.Models;
using CocktailMagician.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Services.Contracts
{
    public interface IBarReviewService
    {
        Task<ICollection<BarReviewDTO>> GetAllBarReviewsAsync(int barId);
        Task<ICollection<BarReviewDTO>> GetAllUserReviewsAsync(int userId);
        Task<BarReviewDTO> GetBarReviewAsync(int barId, int userId);
        Task<BarReviewDTO> CreateBarReviewAsync(BarReviewDTO barReviewDTO);
        Task<BarReviewDTO> UpdateBarReviewAsync(int barId, int userId, BarReviewDTO barReviewDTO);
        Task<bool> DeletBarReviewAsync(int barId, int userId);
    }
}
