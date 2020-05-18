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
    public class IngredientMapper : IIngredientMapper
    {
        private readonly IDatetimeProvider datetimeProvider;

        public IngredientMapper(IDatetimeProvider datetimeProvider)
        {
            this.datetimeProvider = datetimeProvider ?? throw new ArgumentNullException(nameof(datetimeProvider));
        }
        public IngredientDTO MapToIngredientDTO(Ingredient ingredient)
        {
            if (ingredient == null)
            {
                return null;
            }
            var ingredientDTO = new IngredientDTO
            {
                Id = ingredient.Id,
                Name = ingredient.Name,
                Cocktails = ingredient.Cocktails.Select(c => new CocktailDTO
                {
                    Name = c.Cocktail.Name,
                    Id = c.Cocktail.Id
                }).ToList(),
                IsDeleted = ingredient.IsDeleted
            };
            return ingredientDTO;
        }
        public Ingredient MapToIngredient(IngredientDTO ingredientDTO)
        {
            if (ingredientDTO == null)
            {
                return null;
            }
            var ingredient = new Ingredient
            {
                Name = ingredientDTO.Name,
                CreatedOn = ingredientDTO.CreatedOn.HasValue ? ingredientDTO.CreatedOn : datetimeProvider.GetDateTime()
            };
            return ingredient;
        }
    }
}
