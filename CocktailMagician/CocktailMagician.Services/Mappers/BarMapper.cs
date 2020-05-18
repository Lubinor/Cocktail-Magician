using CocktailMagician.Models;
using CocktailMagician.Services.DTOs;
using CocktailMagician.Services.Mappers.Contracts;
using System.Linq;

namespace CocktailMagician.Services.Mappers
{
    public class BarMapper : IBarMapper
    {
        private readonly ICocktailMapper cocktailMapper;
        private readonly IBarReviewMapper reviewMapper;

        public BarMapper(ICocktailMapper cocktailMapper, IBarReviewMapper reviewMapper)
        {
            this.cocktailMapper = cocktailMapper;
            this.reviewMapper = reviewMapper;
        }

        public BarDTO BarToBarDTO(Bar bar)
        {
            BarDTO barDTO = new BarDTO();

            barDTO.Id = bar.Id;
            barDTO.Name = bar.Name;
            barDTO.CityId = bar.CityId;
            barDTO.CityName = bar.City.Name;
            barDTO.Address = bar.Address;
            barDTO.Phone = bar.Phone;
            barDTO.AverageRating = bar.AverageRating;
            barDTO.CreatedOn = bar.CreatedOn;
            barDTO.IsDeleted = bar.IsDeleted;

            var barCocktails = bar.Cocktails
                                    .Select(b => b.Cocktail)
                                    .ToList();
            //TODO samo name i ID s new DTO
            barDTO.Cocktails = barCocktails
                                    .Select(c => new CocktailDTO())
                                    .ToList();

            //TODO new, authorID, authorname, comment, rating
            barDTO.Reviews = bar.Reviews
                                    .Select(b => reviewMapper.BarReviewToBarReviewDTO(b))
                                    .ToList();

            return barDTO;
        }
        public Bar BarDTOtoBar(BarDTO barDTO)
        {
            Bar bar = new Bar();

            bar.Name = barDTO.Name;
            bar.CityId = barDTO.CityId;
            bar.City.Name = barDTO.CityName;
            bar.Address = barDTO.Address;
            bar.Phone = barDTO.Phone;
            bar.AverageRating = barDTO.AverageRating;
            bar.CreatedOn = barDTO.CreatedOn;
            bar.IsDeleted = barDTO.IsDeleted;

            var barCocktails = barDTO.Cocktails
                                    .Select(c => cocktailMapper
                                    .MapToCocktail(c))
                                    .ToList();

            bar.Cocktails = barCocktails
                                    .Select(x => new BarsCocktails { BarId = barDTO.Id, CocktailId = x.Id })
                                    .ToList();

            var barReviews = barDTO.Reviews
                                    .Select(r => reviewMapper.BarReviewDTOtoBarReview(r))
                                    .ToList();

            bar.Reviews = barReviews
                                    .Select(r => new BarsUsersReviews { BarId = barDTO.Id, UserId = r.UserId })
                                    .ToList();

            return bar;
        }
    }
}
