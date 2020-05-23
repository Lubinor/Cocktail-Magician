using CocktailMagician.Data;
using CocktailMagician.Services.Contracts;
using CocktailMagician.Services.DTOs;
using CocktailMagician.Services.Mappers.Contracts;
using CocktailMagician.Services.Providers.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Services
{
    public class CocktailService : ICocktailService
    {
        private readonly IDateTimeProvider datetimeProvider;
        private readonly ICocktailMapper mapper;
        private readonly IIngredientMapper ingredientMapper;
        private readonly CocktailMagicianContext context;

        public CocktailService(IDateTimeProvider datetimeProvider, ICocktailMapper mapper, IIngredientMapper ingredientMapper, CocktailMagicianContext context)
        {
            this.datetimeProvider = datetimeProvider ?? throw new ArgumentNullException(nameof(datetimeProvider));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.ingredientMapper = ingredientMapper ?? throw new ArgumentNullException(nameof(ingredientMapper));
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }
        /// <summary>
        /// Shows all available cocktails, their ingredients and bar/s where are served 
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<CocktailDTO>> GetAllCocktailssAsync()
        {
            var cocktails = this.context.Cocktails
                .Include(cocktail => cocktail.CocktailBars)
                    .ThenInclude(cb => cb.Bar)
                .Include(cocktail => cocktail.IngredientsCocktails)
                    .ThenInclude(ic => ic.Ingredient)
                .Where(cocktail => cocktail.IsDeleted == false);

            var cocktailDTOs = await cocktails.Select(cocktail => mapper.MapToCocktailDTO(cocktail)).ToListAsync();

            return cocktailDTOs;
        }
        /// <summary>
        /// If id exist and the cocktail is not deleted, shows the cocktail with that id, otherwise returns null.
        /// Also shows cocktail ingredients and bar/s where is served
        /// </summary>
        /// <param name="id">The id of the searched cocktail</param>
        /// <returns></returns>
        public async Task<CocktailDTO> GetCocktailAsync(int id)
        {
            var cocktail = await this.context.Cocktails
                .Include(cocktail => cocktail.CocktailBars)
                    .ThenInclude(cb=>cb.Bar)
                .Include(ingredient => ingredient.IngredientsCocktails)
                    .ThenInclude(ic => ic.Ingredient)
                .FirstOrDefaultAsync(cocktail => cocktail.Id == id & cocktail.IsDeleted == false);
            if (cocktail == null)
            {
                return null;
            }
            var cocktailDTO = mapper.MapToCocktailDTO(cocktail);

            var cocktailIngredient = cocktail.IngredientsCocktails.Select(x => x.Ingredient);
            cocktailDTO.Ingredients = cocktailIngredient.Where(c=>c.IsDeleted==false)
                .Select(x => ingredientMapper.MapToIngredientDTO(x)).ToList();

            return cocktailDTO;
        }
        /// <summary>
        /// Create new cocktail entity in the database
        /// </summary>
        /// <param name="coctailDTO"></param>
        /// <returns></returns>
        public async Task<CocktailDTO> CreateCocktailAsync(CocktailDTO coctailDTO)
        {
            if (coctailDTO == null)
            {
                return null;
            }

            var cocktail = mapper.MapToCocktail(coctailDTO);
            cocktail.CreatedOn = datetimeProvider.GetDateTime();

            this.context.Cocktails.Add(cocktail);
            await this.context.SaveChangesAsync();

            return coctailDTO;
        }
        /// <summary>
        /// If id exist and the cocktail is not deleted, update the cocktail with current info from cocktailDTO
        /// </summary>
        /// <param name="id">The id of the cocktail to be updated</param>
        /// <param name="cocktailDTO"></param>
        /// <returns></returns>
        public async Task<CocktailDTO> UpdateCocktailAsync(int id, CocktailDTO cocktailDTO)
        {
            var cocktail = await this.context.Cocktails
                .FirstOrDefaultAsync(cocktail => cocktail.Id == id & cocktail.IsDeleted == false);

            if (cocktail == null)
            {
                return null;
            }

            cocktail = mapper.MapToCocktail(cocktailDTO);

            this.context.Cocktails.Update(cocktail);
            await this.context.SaveChangesAsync();

            return cocktailDTO;
        }
        /// <summary>
        /// If id exist and cocktail is not deleted, set the property "IsDeleted" to true and makes it not visible for users.
        /// </summary>
        /// <param name="id">The id of the cocktail to be deleted</param>
        /// <returns></returns>
        public async Task<bool> DeleteCocktailAsync(int id)
        {
            var cocktail = await this.context.Cocktails
                .FirstOrDefaultAsync(cocktail => cocktail.Id == id & cocktail.IsDeleted == false);

            if (cocktail == null)
            {
                return false;
            }

            cocktail.IsDeleted = true;

            this.context.Cocktails.Update(cocktail);
            await this.context.SaveChangesAsync();

            return true;
        }
        public async Task<ICollection<CocktailDTO>> FilteredCocktailsAsync(string filter)
        {
            var cocktails = this.context.Cocktails.Where(cocktail => cocktail.IsDeleted == false
                && cocktail.Name.Contains(filter) || cocktail.IngredientsCocktails.Any(ing=>ing.Ingredient.Name==filter))
                .Include(ic=>ic.IngredientsCocktails)
                    .ThenInclude(i=>i.Ingredient);

            var cocktailDTOs = await cocktails.Select(cocktail => mapper.MapToCocktailDTO(cocktail)).ToListAsync();

            return cocktailDTOs;
        }
    }
}
