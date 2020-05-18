using CocktailMagician.Models;
using CocktailMagician.Services.DTOs;
using CocktailMagician.Services.Mappers.Contracts;
using CocktailMagician.Services.Provider.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailMagician.Services.Mappers
{
    public class CocktailMapper : ICocktailMapper
    {
        private readonly IDatetimeProvider datetimeProvider;

        public CocktailMapper(IDatetimeProvider datetimeProvider)
        {
            this.datetimeProvider = datetimeProvider ?? throw new ArgumentNullException(nameof(datetimeProvider));
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
                Bars = cocktail.Bars.Select(b => new BarDTO
                {
                    Name = b.Bar.Name
                }).ToList(),
                Ingredients = cocktail.Ingredients.Select(i => new IngredientDTO
                {
                    Name = i.Ingredient.Name
                }).ToList(),
                IsDeleted = cocktail.IsDeleted
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
                Ingredients = cocktailDTO.Ingredients.Select(i => new IngredientsCocktails
                {
                    IngredientId = i.Id
                }).ToList(),
                CreatedOn = cocktailDTO.CreatedOn.HasValue ? cocktailDTO.CreatedOn : datetimeProvider.GetDateTime()
            };

            return cocktail;
        }
    }
}
