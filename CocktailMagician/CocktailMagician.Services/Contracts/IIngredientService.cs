﻿using CocktailMagician.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CocktailMagician.Services.Contracts
{
    public interface IIngredientService
    {
        Task<ICollection<IngredientDTO>> GetAllIngredientsAsync();
        Task<IngredientDTO> GetIngredientAsync(int id);
        Task<IngredientDTO> CreateIngredientAsync(IngredientDTO ingredientDTO);
        Task<IngredientDTO> UpdateIngredientAsync(int id, IngredientDTO ingredientDTO);
        Task<bool> DeleteIngredientAsync(int id);
        Task<IList<IngredientDTO>> ListAllIngredientsAsync(int skip, int pageSize, string searchValue,
            string orderBy, string odrderDirection);
        int GetAllIngredientsCount();
        int GetAllFilteredIngredientsCount(string searchValue);
        public bool IsValid(IngredientDTO ingredientDTO);
    }
}
