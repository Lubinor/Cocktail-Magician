using CocktailMagician.Models;
using CocktailMagician.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Services.Mappers.Contracts
{
    public interface IIngredientMapper
    {
        public IngredientDTO MapToIngredientDTO(Ingredient ingredient);
        public Ingredient MapToIngredient(IngredientDTO ingredientDTO);
    }
}
