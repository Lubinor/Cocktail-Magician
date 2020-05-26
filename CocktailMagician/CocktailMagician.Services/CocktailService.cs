using CocktailMagician.Data;
using CocktailMagician.Services.Contracts;
using CocktailMagician.Services.DTOs;
using CocktailMagician.Services.Mappers.Contracts;
using CocktailMagician.Services.Providers.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
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
        /// <returns>Collection with all cocktails in the database</returns>
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
        /// <returns>Cocktail if id is valid, nothing if id is not valid, or cocktail is already deleted</returns>
        public async Task<CocktailDTO> GetCocktailAsync(int id)
        {
            var cocktail = await this.context.Cocktails
                .Include(cocktail => cocktail.CocktailBars)
                    .ThenInclude(cb => cb.Bar)
                .Include(ingredient => ingredient.IngredientsCocktails)
                    .ThenInclude(ic => ic.Ingredient)
                .FirstOrDefaultAsync(cocktail => cocktail.Id == id & cocktail.IsDeleted == false);
            if (cocktail == null)
            {
                return null;
            }
            var cocktailDTO = mapper.MapToCocktailDTO(cocktail);

            var cocktailIngredient = cocktail.IngredientsCocktails.Select(x => x.Ingredient);
            cocktailDTO.Ingredients = cocktailIngredient.Where(c => c.IsDeleted == false)
                .Select(x => ingredientMapper.MapToIngredientDTO(x)).ToList();

            return cocktailDTO;
        }
        /// <summary>
        /// Create new cocktail entity in the database
        /// </summary>
        /// <param name="coctailDTO">Requested information for creating a new cocktail</param>
        /// <returns>New Coctail</returns>
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
        /// <param name="cocktailDTO">The info which will be updated</param>
        /// <returns>Cocktail updated with new details</returns>
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
        /// <returns>True if cocktail is successfully deleted, False if not</returns>
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
        /// <summary>
        /// Sort the collection of cocktails by cocktail name in ascending or descending order.
        /// By default the collection is sorted by id in ascending order
        /// </summary>
        /// <param name="sort">The sort condition</param>
        /// <returns>Sorted collection of cocktails</returns>
        public async Task<List<CocktailDTO>> SortCocktailsAsync(string sort)
        {
            var cocktails = this.context.Cocktails.Where(cocktail => cocktail.IsDeleted == false)
                .Include(ic => ic.IngredientsCocktails)
                    .ThenInclude(i => i.Ingredient);

            var cocktailDTOs = await cocktails.Select(cocktail => mapper.MapToCocktailDTO(cocktail)).ToListAsync();

            if (sort == null)
            {
                cocktailDTOs = cocktailDTOs.OrderBy(cocktail => cocktail.Id).ToList();
            }

            switch (sort)
            {
                case "name":
                    cocktailDTOs = cocktailDTOs.OrderBy(beer => beer.Name).ToList();
                    break;
                case "name_desc":
                    cocktailDTOs = cocktailDTOs.OrderByDescending(beer => beer.Name).ToList();
                    break;
                default:
                    cocktailDTOs = cocktailDTOs.OrderBy(cocktail => cocktail.Id).ToList();
                    break;
            }

            return cocktailDTOs;
        }
        /// <summary>
        /// Shows all cocktails which names matches "filter", or all cocktails which contains
        /// ingredients with names that matches  "filter".
        /// </summary>
        /// <param name="filter">Searched name of cocktail or ingredient</param>
        /// <returns>Collection of cocktails or empty collection</returns>
        public async Task<List<CocktailDTO>> FilteredCocktailsAsync(string filter)
        {
            var cocktails = this.context.Cocktails
                .Include(ic => ic.IngredientsCocktails)
                    .ThenInclude(i => i.Ingredient)
                 .Where(cocktail => cocktail.IsDeleted == false);

            if (double.TryParse(filter, out double result))
            {
                cocktails = cocktails.Where(cocktail => cocktail.AverageRating >= result);
            }
            else
            {
                cocktails = cocktails.Where(b => b.Name.ToLower().Contains(filter.ToLower()));
            }

            var cocktailDTOs = await cocktails.Select(cocktail => mapper.MapToCocktailDTO(cocktail)).ToListAsync();

            return cocktailDTOs;
        }
    }
}
