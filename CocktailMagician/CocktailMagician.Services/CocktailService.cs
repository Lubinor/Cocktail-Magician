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
using CocktailMagician.Services.Helpers;
using System.Threading.Tasks;
using CocktailMagician.Services.Mappers;
using CocktailMagician.Models;

namespace CocktailMagician.Services
{
    public class CocktailService : ICocktailService
    {
        private readonly IDateTimeProvider datetimeProvider;
        private readonly ICocktailMapper mapper;
        private readonly IIngredientMapper ingredientMapper;
        private readonly IBarMapper barMapper;
        private readonly CocktailMagicianContext context;

        public CocktailService(IDateTimeProvider datetimeProvider, ICocktailMapper mapper,
            IIngredientMapper ingredientMapper, IBarMapper barMapper, CocktailMagicianContext context)
        {
            this.datetimeProvider = datetimeProvider ?? throw new ArgumentNullException(nameof(datetimeProvider));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.ingredientMapper = ingredientMapper ?? throw new ArgumentNullException(nameof(ingredientMapper));
            this.barMapper = barMapper ?? throw new ArgumentNullException(nameof(barMapper));
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
                    .ThenInclude(c => c.City)
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
                    .ThenInclude(c => c.City)
                .Include(ingredient => ingredient.IngredientsCocktails)
                    .ThenInclude(ic => ic.Ingredient)
                .FirstOrDefaultAsync(cocktail => cocktail.Id == id & cocktail.IsDeleted == false);
            if (cocktail == null)
            {
                return null;
            }
            var cocktailDTO = mapper.MapToCocktailDTO(cocktail);

            var cocktailIngredient = cocktail.IngredientsCocktails.Select(x => x.Ingredient);
            var cocktailBars = cocktail.CocktailBars.Select(x => x.Bar);
            cocktailDTO.Ingredients = cocktailIngredient.Where(c => c.IsDeleted == false)
                .Select(x => ingredientMapper.MapToIngredientDTO(x)).ToList();
            cocktailDTO.Bars = cocktailBars.Where(b => b.IsDeleted == false)
                .Select(bdto => barMapper.MapToBarDTO(bdto)).ToList();

            return cocktailDTO;
        }
        /// <summary>
        /// Create new cocktail entity in the database
        /// </summary>
        /// <param name="coctailDTO">Requested information for creating a new cocktail</param>
        /// <returns>New Coctail</returns>
        public async Task<CocktailDTO> CreateCocktailAsync(CocktailDTO cocktailDTO)
        {
            if (!IsValid(cocktailDTO))
            {
                return null;
            }

            var cocktail = mapper.MapToCocktail(cocktailDTO);
            cocktail.CreatedOn = datetimeProvider.GetDateTime();

            this.context.Cocktails.Add(cocktail);
            await this.context.SaveChangesAsync();

            return cocktailDTO;
        }
        /// <summary>
        /// If id exist and the cocktail is not deleted, update the cocktail with current info from cocktailDTO
        /// </summary>
        /// <param name="id">The id of the cocktail to be updated</param>
        /// <param name="cocktailDTO">The info which will be updated</param>
        /// <returns>Cocktail updated with new details</returns>
        public async Task<CocktailDTO> UpdateCocktailAsync(int id, CocktailDTO cocktailDTO)
        {
            if (!IsValid(cocktailDTO))
            {
                return null;
            }
            var cocktail = await this.context.Cocktails
                .Include(ingredient => ingredient.IngredientsCocktails)
                .Include(bar => bar.CocktailBars)
                .FirstOrDefaultAsync(cocktail => cocktail.Id == id & cocktail.IsDeleted == false);

            if (cocktail == null)
            {
                return null;
            }


            this.context.IngredientsCocktails.RemoveRange(cocktail.IngredientsCocktails);
            this.context.BarsCocktails.RemoveRange(cocktail.CocktailBars);

            cocktail.Name = cocktailDTO.Name;
            cocktail.CocktailBars = new List<BarsCocktails>();
            foreach (var item in cocktailDTO.Bars)
            {
                cocktail.CocktailBars.Add(new BarsCocktails { BarId = item.Id, CocktailId = cocktail.Id });
            }
            cocktail.IngredientsCocktails = new List<IngredientsCocktails>();
            foreach (var item in cocktailDTO.Ingredients)
            {
                cocktail.IngredientsCocktails.Add(new IngredientsCocktails { IngredientId = item.Id, CocktailId = cocktail.Id });
            }

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
                    cocktailDTOs = cocktailDTOs.OrderBy(cocktail => cocktail.Name).ToList();
                    break;
                case "name_desc":
                    cocktailDTOs = cocktailDTOs.OrderByDescending(cocktail => cocktail.Name).ToList();
                    break;
                default:
                    cocktailDTOs = cocktailDTOs.OrderBy(cocktail => cocktail.Id).ToList();
                    break;
            }

            return cocktailDTOs;
        }
        /// <summary>
        /// Shows all cocktails which names matches "filter", or all cocktails which contains
        /// ingredients with names that matches  "filter". Or if filter is number, shows all cocktails
        /// with rating above and equal to that number
        /// </summary>
        /// <param name="filter">Searched name of cocktail or ingredient. Or searched rating</param>
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
                cocktails = cocktails.Where(cocktail => cocktail.Name.ToLower().Contains(filter.ToLower())
                || cocktail.IngredientsCocktails.Any(ing => ing.Ingredient.Name.ToLower() == filter.ToLower()));
            }

            var cocktailDTOs = await cocktails.Select(cocktail => mapper.MapToCocktailDTO(cocktail)).ToListAsync();

            return cocktailDTOs;
        }

        public async Task<IList<CocktailDTO>> ListAllCocktailsAsync(int skip, int pageSize, string searchValue,
            string orderBy, string orderDirection)
        {
            var cocktails = this.context.Cocktails
                .Include(cocktail => cocktail.IngredientsCocktails)
                    .ThenInclude(i => i.Ingredient)
                .Include(cocktail => cocktail.CocktailBars)
                    .ThenInclude(b => b.Bar)
                .Where(cocktail => cocktail.IsDeleted == false);

            if (!String.IsNullOrEmpty(orderBy))
            {
                if (String.IsNullOrEmpty(orderDirection) || orderDirection == "asc")
                {
                    cocktails = cocktails.OrderBy(orderBy);
                }
                else
                {
                    cocktails = cocktails.OrderByDescending(orderBy);
                }
            }

            if (!string.IsNullOrEmpty(searchValue))
            {
                searchValue = searchValue.ToLower();

                cocktails = cocktails
                     .Where(cocktail => cocktail.Name.ToLower()
                     .StartsWith(searchValue));
            }

            cocktails = cocktails
                .Skip(skip)
                .Take(pageSize);

            var cocktailDTOs = await cocktails.Select(cocktail => mapper.MapToCocktailDTO(cocktail)).ToListAsync();

            return cocktailDTOs;
        }
        public int GetAllCocktailsCount()
        {
            return this.context.Cocktails.Where(cocktail => cocktail.IsDeleted == false).Count();
        }
        public int GetAllFilteredCocktailsCount(string searchValue)
        {

            if (!string.IsNullOrEmpty(searchValue))
            {
                searchValue = searchValue.ToLower();

                var cocktails = this.context.Cocktails
                     .Where(cocktail => cocktail.Name.ToLower().Contains(searchValue));
                return cocktails.Count();
            }
            return this.context.Cocktails.Where(cocktail => cocktail.IsDeleted == false).Count();
        }
        private bool IsValid(CocktailDTO cocktailDTO)
        {
            if (cocktailDTO == null)
            {
                throw new ArgumentNullException();
            }
            if (cocktailDTO.Name == string.Empty || !cocktailDTO.Name.Any(x => char.IsLetterOrDigit(x)))
            {
                throw new ArgumentException();
            }

            if (context.Ingredients.Select(i => i.Name.ToLower()).Contains(cocktailDTO.Name.ToLower()))
            {
                throw new Exception();
            }
            return true;
        }
        private double GetCocktailRating(int cocktailId)
        {
            var allReviews = this.context.CocktailsUsersReviews
                .Where(c => c.CocktailId == cocktailId && !c.IsDeleted);

            int ratingSum = allReviews.Select(r => r.Rating).Sum();

            double averageRating = 0.00;

            if (ratingSum > 0)
            {
                averageRating = (ratingSum * 1.00) / allReviews.Count();
            }

            averageRating = Math.Round(averageRating, 2);

            return averageRating;
        }
    }
}
