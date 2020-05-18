using CocktailMagician.Models;
using CocktailMagician.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
