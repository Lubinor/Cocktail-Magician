﻿using CocktailMagician.Data;
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
        private readonly ICocktailReviewService reviewService;

        public CocktailService(IDateTimeProvider datetimeProvider, ICocktailMapper mapper,
            IIngredientMapper ingredientMapper, IBarMapper barMapper, CocktailMagicianContext context, ICocktailReviewService reviewService)
        {
            this.datetimeProvider = datetimeProvider ?? throw new ArgumentNullException(nameof(datetimeProvider));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.ingredientMapper = ingredientMapper ?? throw new ArgumentNullException(nameof(ingredientMapper));
            this.barMapper = barMapper ?? throw new ArgumentNullException(nameof(barMapper));
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.reviewService = reviewService ?? throw new ArgumentNullException(nameof(reviewService));
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

            foreach (var cocktail in cocktailDTOs)
            {
                cocktail.AverageRating = this.reviewService.GetCocktailRating(cocktail.Id);
            }

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

            cocktailDTO.AverageRating = this.reviewService.GetCocktailRating(id);

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
            if (context.Ingredients.Select(i => i.Name.ToLower()).Contains(cocktailDTO.Name.ToLower()))
            {
                throw new Exception();
            }

            var cocktail = mapper.MapToCocktail(cocktailDTO);
            cocktail.CreatedOn = datetimeProvider.GetDateTime();

            string imageBase64Data = Convert.ToBase64String(cocktail.ImageData);
            cocktail.ImageSource = string.Format("data:image/jpg;base64,{0}", imageBase64Data);

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

            cocktail.ImageData = cocktailDTO.ImageData;

            string imageBase64Data = Convert.ToBase64String(cocktail.ImageData);
            cocktail.ImageSource = string.Format("data:image/jpg;base64,{0}", imageBase64Data);

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
                     .Contains(searchValue.ToLower()));
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
            if (cocktailDTO.Name == string.Empty || !cocktailDTO.Name.All(x => char.IsLetterOrDigit(x)))
            {
                throw new ArgumentException();
            }
            if (cocktailDTO.Name.Length<2||cocktailDTO.Name.Length>30)
            {
                throw new Exception();
            }
            
            return true;
        }
    }
}
