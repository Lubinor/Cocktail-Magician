using CocktailMagician.Models;
using CocktailMagician.Services.DTOs;
using CocktailMagician.Services.Mappers.Contracts;
using CocktailMagician.Services.Providers.Contracts;
using System;
using System.Linq;

namespace CocktailMagician.Services.Mappers
{
    public class CocktailMapper : ICocktailMapper
    {
        private readonly IDateTimeProvider datetimeProvider;

        public CocktailMapper(IDateTimeProvider datetimeProvider)
        {
            this.datetimeProvider = datetimeProvider ?? throw new ArgumentNullException(nameof(datetimeProvider));
        }
        public CocktailMapper()
        {

        }
        public CocktailDTO MapToCocktailDTO(Cocktail cocktail)
        {
            if (cocktail == null)
            {
                return null;
            }
            var cocktailDTO = new CocktailDTO
            {
                Id = cocktail.Id,
                Name = cocktail.Name,
                AverageRating = cocktail.AverageRating,
                Bars = cocktail.CocktailBars.Select(b => new BarDTO
                {
                    Name = b.Bar.Name
                }).ToList(),
                Ingredients = cocktail.IngredientsCocktails.Select(i => new IngredientDTO
                {
                    Name = i.Ingredient.Name
                }).ToList(),
                //IsDeleted = cocktail.IsDeleted
            };
            return cocktailDTO;
        }
        public Cocktail MapToCocktail(CocktailDTO cocktailDTO)
        {
            if (cocktailDTO == null)
            {
                return null;
            }

            var cocktail = new Cocktail
            {
                Name = cocktailDTO.Name,
                IngredientsCocktails = cocktailDTO.Ingredients.Select(i => new IngredientsCocktails
                {
                    IngredientId = i.Id
                }).ToList(),
                //CreatedOn = cocktailDTO.CreatedOn.HasValue ? cocktailDTO.CreatedOn : datetimeProvider.GetDateTime()
            };

            return cocktail;
        }
    }
}
