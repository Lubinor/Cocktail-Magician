using CocktailMagician.Data;
using CocktailMagician.Models;
using CocktailMagician.Services.Contracts;
using CocktailMagician.Services.DTOs;
using CocktailMagician.Services.Mappers.Contracts;
using CocktailMagician.Services.Provider.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IDatetimeProvider datetimeProvider;
        private readonly IIngredientMapper mapper;
        private readonly CocktailMagicianContext context;

        public IngredientService(IDatetimeProvider datetimeProvider, IIngredientMapper mapper, CocktailMagicianContext context)
        {
            this.datetimeProvider = datetimeProvider ?? throw new ArgumentNullException(nameof(datetimeProvider));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<ICollection<IngredientDTO>> GetAllIngredientsAsync()
        {
            var ingredients = this.context.Ingredients
                .Include(ingredient => ingredient.Cocktails)
                .Where(ingredient => ingredient.IsDeleted == false);

            var ingredientDTOs = await ingredients.Select(ingredient => mapper.MapToIngredientDTO(ingredient)).ToListAsync();

            return ingredientDTOs;

        }
        public async Task<IngredientDTO> GetIngredientAsync(int id)
        {
            var ingredient = await this.context.Ingredients
                .Include(ingredient => ingredient.Cocktails)
                .FirstOrDefaultAsync(ingredient => ingredient.Id == id & ingredient.IsDeleted == false);

            if (ingredient == null)
            {
                return null;
            }

            var ingredientDTO = mapper.MapToIngredientDTO(ingredient);

            return ingredientDTO;
        }
        public async Task<IngredientDTO> CreateIngredientAsync(IngredientDTO ingredientDTO)
        {
            if (ingredientDTO == null)
            {
                return null;
            }

            var ingredient = mapper.MapToIngredient(ingredientDTO);

            this.context.Ingredients.Add(ingredient);
            await this.context.SaveChangesAsync();

            return ingredientDTO;
        }
        public async Task<IngredientDTO> UpdateIngredientAsync(int id, IngredientDTO ingredientDTO)
        {
            var ingredient = await this.context.Ingredients
                .FirstOrDefaultAsync(ingredient => ingredient.Id == id & ingredient.IsDeleted == false);

            if (ingredient == null)
            {
                return null;
            }
            
            ingredient = mapper.MapToIngredient(ingredientDTO);

            this.context.Ingredients.Update(ingredient);
            await this.context.SaveChangesAsync();

            return ingredientDTO;
        }
        public async Task<bool> DeleteIngredientAsync(int id)
        {
            var ingredient = await this.context.Ingredients
                .Include(ingredient => ingredient.Cocktails)
                .FirstOrDefaultAsync(ingredient => ingredient.Id == id & ingredient.IsDeleted == false);

            if (ingredient == null)
            {
                return false;
            }

            if (ingredient.Cocktails != null)
            {
                throw new Exception($"Ingredient still in use");
            }
            else
            {
                ingredient.IsDeleted = true;
                await this.context.SaveChangesAsync();
                return true;
            }
        }
    }
}
