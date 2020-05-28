using CocktailMagician.Data;
using CocktailMagician.Models;
using CocktailMagician.Services.Contracts;
using CocktailMagician.Services.DTOs;
using CocktailMagician.Services.Mappers.Contracts;
using CocktailMagician.Services.Providers.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Services
{
    public class BarReviewService : IBarReviewService
    {
        private readonly IDateTimeProvider dateTimeProvider;
        private readonly CocktailMagicianContext context;
        private readonly IBarReviewMapper barReviewMapper;

        public BarReviewService(IDateTimeProvider dateTimeProvider, CocktailMagicianContext context, IBarReviewMapper barReviewMapper)
        {
            this.dateTimeProvider = dateTimeProvider ?? throw new ArgumentNullException(nameof(dateTimeProvider));
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.barReviewMapper = barReviewMapper ?? throw new ArgumentNullException(nameof(barReviewMapper));
        }

        public async Task<ICollection<BarReviewDTO>> GetAllBarReviewsAsync(int barId)
        {
            var barReviewDTOs = await this.context.BarsUsersReviews
                .Include(r => r.Bar)
                .Include(r => r.User)
                .Where(r => r.BarId == barId && !r.IsDeleted)
                .Select(x => barReviewMapper.MapToBarReviewDTO(x))
                .ToListAsync();

            return barReviewDTOs;
        }

        public async Task<ICollection<BarReviewDTO>> GetAllUserReviewsAsync(int userId)
        {
            var barReviewDTOs = await this.context.BarsUsersReviews
                .Include(r => r.Bar)
                .Include(r => r.User)
                .Where(r => r.UserId == userId && !r.IsDeleted)
                .Select(x => barReviewMapper.MapToBarReviewDTO(x))
                .ToListAsync();

            return barReviewDTOs;
        }

        public async Task<BarReviewDTO> GetBarReviewAsync(int barId, int userId)
        {
            var barReview = await this.context.BarsUsersReviews
                .Include(r => r.Bar)
                .Include(r => r.User)
                .FirstOrDefaultAsync(r => r.BarId == barId &&
                                          r.UserId == userId &&
                                         !r.IsDeleted);

            if (barReview == null)
            {
                return null;
            }

            var barReviewDTO = this.barReviewMapper.MapToBarReviewDTO(barReview);

            return barReviewDTO;
        }

        public async Task<BarReviewDTO> CreateBarReviewAsync(BarReviewDTO barReviewDTO)
        {
            if (barReviewDTO == null)
            {
                return null;
            };

            var barReview = this.barReviewMapper.MapToBarReview(barReviewDTO);
            barReview.CreatedOn = this.dateTimeProvider.GetDateTime();

            this.context.BarsUsersReviews.Add(barReview);
            await this.context.SaveChangesAsync();

            var newBarReviewDTO = this.barReviewMapper.MapToBarReviewDTO(barReview);

            return newBarReviewDTO;
        }

        public async Task<BarReviewDTO> UpdateBarReviewAsync(int barId, int userId, BarReviewDTO barReviewDTO)
        {
            if (barReviewDTO == null)
            {
                return null;
            };

            var barReview = await this.context.BarsUsersReviews
                .FirstOrDefaultAsync(r => r.BarId == barId &&
                                          r.UserId == userId &&
                                         !r.IsDeleted);

            if (barReview == null)
            {
                return null;
            }

            barReview.Comment = barReviewDTO.Comment;
            barReview.Rating = barReviewDTO.Rating;

            this.context.BarsUsersReviews.Update(barReview);
            await this.context.SaveChangesAsync();

            var newBarReviewDTO = this.barReviewMapper.MapToBarReviewDTO(barReview);

            return newBarReviewDTO;
        }

        public async Task<bool> DeleteBarReviewAsync(int barId, int userId)
        {
            var barReview = await this.context.BarsUsersReviews
                .Include(r => r.Bar)
                .Include(r => r.User)
                .FirstOrDefaultAsync(r => r.BarId == barId &&
                                          r.UserId == userId &&
                                         !r.IsDeleted);

            if (barReview == null)
            {
                return false;
            }

            barReview.IsDeleted = true;

            this.context.BarsUsersReviews.Update(barReview);
            await this.context.SaveChangesAsync();

            return true;
        }
    }
}
