using CocktailMagician.Data;
using CocktailMagician.Services.Contracts;
using CocktailMagician.Services.DTOs;
using CocktailMagician.Services.Mappers.Contracts;
using CocktailMagician.Services.Providers.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;

namespace CocktailMagician.Services
{
    public class CocktailReviewService : ICocktailReviewService
    {
        private readonly IDateTimeProvider dateTimeProvider;
        private readonly CocktailMagicianContext context;
        private readonly ICocktailReviewMapper cocktailReviewMapper;

        public CocktailReviewService(IDateTimeProvider dateTimeProvider, CocktailMagicianContext context, ICocktailReviewMapper cocktailReviewMapper)
        {
            this.dateTimeProvider = dateTimeProvider ?? throw new ArgumentNullException(nameof(dateTimeProvider));
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.cocktailReviewMapper = cocktailReviewMapper ?? throw new ArgumentNullException(nameof(cocktailReviewMapper));
        }

        public async Task<ICollection<CocktailReviewDTO>> GetAllCocktailReviewsAsync(int cocktailId)
        {
            var CocktailReviewDTOs = await this.context.CocktailsUsersReviews
                .Include(r => r.Cocktail)
                .Include(r => r.User)
                .Where(r => r.CocktailId == cocktailId && !r.IsDeleted)
                .Select(x => cocktailReviewMapper.MapToCocktailReviewDTO(x))
                .ToListAsync();

            return CocktailReviewDTOs;
        }

        public async Task<ICollection<CocktailReviewDTO>> GetAllUserReviewsAsync(int userId)
        {
            var barReviewDTOs = await this.context.CocktailsUsersReviews
                .Include(r => r.Cocktail)
                .Include(r => r.User)
                .Where(r => r.UserId == userId && !r.IsDeleted)
                .Select(x => cocktailReviewMapper.MapToCocktailReviewDTO(x))
                .ToListAsync();

            return barReviewDTOs;
        }

        public async Task<CocktailReviewDTO> GetCocktailReviewAsync(int cocktailId, int userId)
        {
            var cocktailReview = await this.context.CocktailsUsersReviews
                .Include(r => r.Cocktail)
                .Include(r => r.User)
                .FirstOrDefaultAsync(r => r.CocktailId == cocktailId &&
                                          r.UserId == userId &&
                                         !r.IsDeleted);

            if (cocktailReview == null)
            {
                return null;
            }

            var cocktailReviewDTO = this.cocktailReviewMapper.MapToCocktailReviewDTO(cocktailReview);

            return cocktailReviewDTO;
        }

        public async Task<CocktailReviewDTO> CreateCocktailReviewAsync(CocktailReviewDTO cocktailReviewDTO)
        {
            if (cocktailReviewDTO == null)
            {
                return null;
            };

            var cocktailReview = this.cocktailReviewMapper.MapToCocktailReview(cocktailReviewDTO);
            cocktailReview.CreatedOn = this.dateTimeProvider.GetDateTime();

            this.context.CocktailsUsersReviews.Add(cocktailReview);
            await this.context.SaveChangesAsync();

            var newCocktailReviewDTO = this.cocktailReviewMapper.MapToCocktailReviewDTO(cocktailReview);

            return newCocktailReviewDTO;
        }

        public async Task<CocktailReviewDTO> UpdateCocktailReviewAsync(int cocktailId, int userId, CocktailReviewDTO cocktailReviewDTO)
        {
            if (cocktailReviewDTO == null)
            {
                return null;
            };

            var cocktailReview = await this.context.CocktailsUsersReviews
                .FirstOrDefaultAsync(r => r.CocktailId == cocktailId &&
                                          r.UserId == userId &&
                                         !r.IsDeleted);

            if (cocktailReview == null)
            {
                return null;
            }

            cocktailReview.Comment = cocktailReviewDTO.Comment;
            cocktailReview.Rating = cocktailReviewDTO.Rating;

            this.context.CocktailsUsersReviews.Update(cocktailReview);
            await this.context.SaveChangesAsync();

            var newCocktailReviewDTO = this.cocktailReviewMapper.MapToCocktailReviewDTO(cocktailReview);

            return newCocktailReviewDTO;
        }

        public async Task<bool> DeleteCocktailReviewAsync(int cocktailId, int userId)
        {
            var cocktailReview = await this.context.CocktailsUsersReviews
                .Include(r => r.Cocktail)
                .Include(r => r.User)
                .FirstOrDefaultAsync(r => r.CocktailId == cocktailId &&
                                          r.UserId == userId &&
                                         !r.IsDeleted);

            if (cocktailReview == null)
            {
                return false;
            }

            cocktailReview.IsDeleted = true;

            this.context.CocktailsUsersReviews.Update(cocktailReview);
            await this.context.SaveChangesAsync();

            return true;
        }
    }
}
