using CocktailMagician.Models;
using CocktailMagician.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailMagician.Services.Mapper
{
    public class Mapper
    {
        private readonly Ingredient ingredient;
        private readonly IngredientDTO ingredientDTO;
        private readonly Cocktail cocktail;
        private readonly CocktailDTO coctailDTO;

        public Mapper(Ingredient ingredient, IngredientDTO ingredientDTO,Cocktail cocktail, CocktailDTO coctailDTO)
        {
            this.ingredient = ingredient ?? throw new ArgumentNullException(nameof(ingredient));
            this.ingredientDTO = ingredientDTO ?? throw new ArgumentNullException(nameof(ingredientDTO));
            this.cocktail = cocktail ?? throw new ArgumentNullException(nameof(cocktail));
            this.coctailDTO = coctailDTO ?? throw new ArgumentNullException(nameof(coctailDTO));
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
                Name = ingredientDTO.Name
            };
            return ingredient;
        }
        public CocktailDTO MapToCoctailDTO(Cocktail cocktail)
        {
            if (cocktail == null)
            {
                return null;
            }
            var coctailDTO = new CocktailDTO
            {
                Id = cocktail.Id,
                Name = cocktail.Name,
                AverageRating = cocktail.AverageRating,
                Ingredients = cocktail.Ingredients.Select(i => new IngredientDTO
                {
                    Name = i.Ingredient.Name
                }).ToList(),
                IsDeleted = cocktail.IsDeleted
            };
            return coctailDTO;
        }
        public Cocktail MapToCoctail(CocktailDTO coctailDTO)
        {
            if (coctailDTO ==null)
            {
                return null;
            }
            var coctail = new Cocktail
            {
                Name = coctailDTO.Name
            };
            return coctail;
        }
    }
}
