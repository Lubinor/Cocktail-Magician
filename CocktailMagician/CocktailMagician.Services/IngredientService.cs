using CocktailMagician.Data;
using CocktailMagician.Models;
using CocktailMagician.Services.Contracts;
using CocktailMagician.Services.DTOs;
using CocktailMagician.Services.Helpers;
using CocktailMagician.Services.Mappers.Contracts;
using CocktailMagician.Services.Providers.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;

namespace CocktailMagician.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IDateTimeProvider datetimeProvider;
        private readonly IIngredientMapper mapper;
        private readonly ICocktailMapper cocktailMapper;
        private readonly CocktailMagicianContext context;

        public IngredientService(IDateTimeProvider datetimeProvider, IIngredientMapper mapper,
            ICocktailMapper cocktailMapper, CocktailMagicianContext context)
        {
            this.datetimeProvider = datetimeProvider ?? throw new ArgumentNullException(nameof(datetimeProvider));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.cocktailMapper = cocktailMapper ?? throw new ArgumentNullException(nameof(cocktailMapper));
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }
        /// <summary>
        /// Shows all available ingredients.
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<IngredientDTO>> GetAllIngredientsAsync()
        {
            var ingredients = this.context.Ingredients
                .Include(ingredient => ingredient.IngredientsCocktails)
                .ThenInclude(ic => ic.Cocktail)
                .Where(ingredient => ingredient.IsDeleted == false);

            var ingredientDTOs = await ingredients.Select(ingredient => mapper.MapToIngredientDTO(ingredient)).ToListAsync();

            return ingredientDTOs;

        }
        /// <summary>
        /// If id exist and the ingredient is not deleted, shows the ingredient with that id, otherwise returns null.
        /// </summary>
        /// <param name="id">The id of searched ingredient</param>
        /// <returns></returns>
        public async Task<IngredientDTO> GetIngredientAsync(int id)
        {
            var ingredient = await this.context.Ingredients
                .Include(ingredient => ingredient.IngredientsCocktails)
                .ThenInclude(ic => ic.Cocktail)
                .FirstOrDefaultAsync(ingredient => ingredient.Id == id & ingredient.IsDeleted == false);

            if (ingredient == null)
            {
                return null;
            }

            var ingredientDTO = mapper.MapToIngredientDTO(ingredient);
            var ingredientCocktails = ingredient.IngredientsCocktails.Select(x => x.Cocktail);
            ingredientDTO.CocktailDTOs = ingredientCocktails.Where(c => c.IsDeleted == false)
                .Select(x => cocktailMapper.MapToCocktailDTO(x)).ToList();

            return ingredientDTO;
        }
        /// <summary>
        /// Create new ingredient entity in the database.
        /// </summary>
        /// <param name="ingredientDTO"></param>
        /// <returns></returns>
        public async Task<IngredientDTO> CreateIngredientAsync(IngredientDTO ingredientDTO)
        {
            //TODO: MORE VALIDATIONS HERE
            if (ingredientDTO.Name == string.Empty)
            {
                return null;
            }

            var ingredient = mapper.MapToIngredient(ingredientDTO);
            ingredient.CreatedOn = datetimeProvider.GetDateTime();

            this.context.Ingredients.Add(ingredient);
            await this.context.SaveChangesAsync();

            return ingredientDTO;
        }
        /// <summary>
        /// If id exist and the ingredient is not deleted, update the ingredient with current info from ingredientDTO
        /// </summary>
        /// <param name="id">The id of the ingredient to be updated</param>
        /// <param name="ingredientDTO"></param>
        /// <returns></returns>
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
        /// <summary>
        /// If id exist and the ingredient is not deleted or not used in any cocktail, set the property "IsDeleted" to true and makes it
        /// not visible for users. Otherwise ingredient can not be deleted.
        /// </summary>
        /// <param name="id">The id of the ingredient to be deleted</param>
        /// <returns></returns>
        public async Task<bool> DeleteIngredientAsync(int id)
        {
            var ingredient = await this.context.Ingredients
                .Include(ingredient => ingredient.IngredientsCocktails)
                .ThenInclude(ic => ic.Cocktail)
                .FirstOrDefaultAsync(ingredient => ingredient.Id == id & ingredient.IsDeleted == false);

            if (ingredient == null)
            {
                return false;
            }

            if (ingredient.IngredientsCocktails.Any(c => c.IngredientId == id)) // no test for this if
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
        //public async Task<List<IngredientDTO>> SortIngredientsAsync(string sort)
        //{
        //    var ingredients = this.context.Ingredients.Where(ingredient => ingredient.IsDeleted == false)
        //        .Include(ic => ic.IngredientsCocktails)
        //            .ThenInclude(c => c.Cocktail);

        //    var ingredientDTOs = await ingredients.Select(ingredient => mapper.MapToIngredientDTO(ingredient)).ToListAsync();

        //    if (sort == null)
        //    {
        //        ingredientDTOs = ingredientDTOs.OrderBy(cocktail => cocktail.Id).ToList();
        //    }

        //    switch (sort)
        //    {
        //        case "asc":
        //            ingredientDTOs = ingredientDTOs.OrderBy(ingredient => ingredient.Name).ToList();
        //            break;
        //        case "desc":
        //            ingredientDTOs = ingredientDTOs.OrderByDescending(ingredient => ingredient.Name).ToList();
        //            break;
        //        default:
        //            ingredientDTOs = ingredientDTOs.OrderBy(ingredient => ingredient.Id).ToList();
        //            break;
        //    }

        //    return ingredientDTOs;
        //}
        public async Task<IList<IngredientDTO>> ListAllIngredientsAsync(int skip, int pageSize, string searchValue,
            string orderBy, string orderDirection)
        {
            var ingredients = this.context.Ingredients
                .Include(ingredient => ingredient.IngredientsCocktails)
                .ThenInclude(ic => ic.Cocktail)
                .Where(ingredient => ingredient.IsDeleted == false);

            if (!String.IsNullOrEmpty(orderBy))
            {
                if (String.IsNullOrEmpty(orderDirection) || orderDirection == "asc")
                {
                    ingredients = ingredients.OrderBy(orderBy);
                }
                else
                {
                    ingredients = ingredients.OrderByDescending(orderBy);
                }
            }

            if (!string.IsNullOrEmpty(searchValue))
            {
                searchValue = searchValue.ToLower();

                ingredients = ingredients
                     .Where(ingredient => ingredient.Name.ToLower()
                     .StartsWith(searchValue));
            }

            ingredients = ingredients
                .Skip(skip)
                .Take(pageSize);

            var ingredientDTOs = await ingredients.Select(ingredient => mapper.MapToIngredientDTO(ingredient)).ToListAsync();

            return ingredientDTOs;
        }
        /// <summary>
        /// Returns the count of all not deleted ingredients
        /// </summary>
        /// <returns></returns>
        public int GetAllIngredientsCount()
        {
            return this.context.Ingredients.Where(ingredient => ingredient.IsDeleted == false).Count();
        }
        /// <summary>
        /// Returns the count of all ingredients which names contains searchValue. If searchValue is null or
        /// empty string - returns the count of all not deleted ingredients
        /// </summary>
        /// <param name="searchValue">char or string that is contained by ingredient name</param>
        /// <returns></returns>
        public int GetAllFilteredIngredientsCount(string searchValue)
        {

            if (!string.IsNullOrEmpty(searchValue))
            {
                searchValue = searchValue.ToLower();

                var ingredients = this.context.Ingredients
                     .Where(ingredient => ingredient.Name.ToLower().Contains(searchValue));
                return ingredients.Count();
            }
            return this.context.Ingredients.Where(ingredient => ingredient.IsDeleted == false).Count();
        }
    }
}
