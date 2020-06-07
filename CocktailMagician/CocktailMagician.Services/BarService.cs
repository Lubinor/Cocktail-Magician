using CocktailMagician.Data;
using CocktailMagician.Models;
using CocktailMagician.Services.Contracts;
using CocktailMagician.Services.DTOs;
using CocktailMagician.Services.Helpers;
using CocktailMagician.Services.Mappers.Contracts;
using CocktailMagician.Services.Providers.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;

namespace CocktailMagician.Services
{
    public class BarService : IBarService
    {
        private readonly IDateTimeProvider dateTimeProvider;
        private readonly CocktailMagicianContext context;
        private readonly IBarMapper barMapper;

        public BarService(IDateTimeProvider dateTimeProvider, CocktailMagicianContext context, IBarMapper barMapper)
        {
            this.dateTimeProvider = dateTimeProvider ?? throw new ArgumentNullException(nameof(dateTimeProvider));
            this.context = context ?? throw new ArgumentNullException(nameof(context)); ;
            this.barMapper = barMapper ?? throw new ArgumentNullException(nameof(barMapper));
        }

        public async Task<ICollection<BarDTO>> GetAllBarsAsync(string sortMethod = null)
        {
            var bars = this.context.Bars
                .Include(b => b.BarCocktails)
                    .ThenInclude(b => b.Cocktail)
                .Include(b => b.City)
                .Where(b => !b.IsDeleted);

            bars = sortMethod switch
            {
                "name" => bars.OrderBy(b => b.Name),
                "name_desc" => bars.OrderByDescending(b => b.Name),
                _ => bars.OrderBy(b => b.Id),
            };


            var barDTOs = await bars
                .Select(b => this.barMapper.MapToBarDTO(b))
                .ToListAsync();

            //foreach (var bar in barDTOs)
            //{
            //    bar.AverageRating = GetBarRating(bar.Id);
            //}

            return barDTOs;
        }

        public async Task<BarDTO> GetBarAsync(int id)
        {
            var bar = await this.context.Bars
                .Include(b => b.BarCocktails)
                    .ThenInclude(b => b.Cocktail)
                .Include(b => b.City)
                .FirstOrDefaultAsync(b => !b.IsDeleted && b.Id == id);

            if (bar == null)
            {
                return null;
            }

            var barDTO = this.barMapper.MapToBarDTO(bar);

            //barDTO.AverageRating = GetBarRating(barDTO.Id);

            return barDTO;
        }

        public async Task<BarDTO> CreateBarAsync(BarDTO barDTO)
        {
            if (barDTO == null)
            {
                return null;
            }

            //TODO check with Ivo for unique 
            var bar = this.barMapper.MapToBar(barDTO);

            string imageBase64Data = Convert.ToBase64String(bar.ImageData);
            bar.ImageSource = string.Format("data:image/jpg;base64,{0}", imageBase64Data);

            bar.CreatedOn = dateTimeProvider.GetDateTime();

            this.context.Bars.Add(bar);
            await this.context.SaveChangesAsync();

            var newBarDTO = await this.GetBarAsync(bar.Id);

            return newBarDTO;
        }

        public async Task<BarDTO> UpdateBarAsync(int id, BarDTO barDTO)
        {
            var bar = await this.context.Bars
                .Include(b => b.BarCocktails)
                    .ThenInclude(b => b.Cocktail)
                .Include(b => b.City)
                .FirstOrDefaultAsync(b => !b.IsDeleted && b.Id == id);

            if (bar == null)
            {
                return null;
            }

            bar.Name = barDTO.Name;
            bar.CityId = barDTO.CityId;
            bar.Address = barDTO.Address;
            bar.Phone = barDTO.Phone;

            this.context.Bars.Update(bar);
            await this.context.SaveChangesAsync();

            var updatedBarDTO = await this.GetBarAsync(bar.Id);

            return updatedBarDTO;
        }

        public async Task<bool> DeleteBarAsync(int id)
        {
            var bar = await this.context.Bars
                .Include(b => b.BarReviews)
                .FirstOrDefaultAsync(b => !b.IsDeleted && b.Id == id);

            if (bar == null)
            {
                return false;
            }

            bar.IsDeleted = true;

            foreach (var review in bar.BarReviews)
            {
                review.IsDeleted = true;
                this.context.BarsUsersReviews.Update(review);
            }

            this.context.Bars.Update(bar);
            await this.context.SaveChangesAsync();

            return true;
        }

        public async Task<ICollection<BarDTO>> FilterBarsAsync(string filter)
        {
            if (filter == null)
            {
                return null;
            }

            var bars = this.context.Bars
                .Include(b => b.BarCocktails)
                .Where(b => !b.IsDeleted);

            if (double.TryParse(filter, out double result))
            {
                bars = bars.Where(b => b.AverageRating >= result);
            }
            else
            {
                bars = bars.Where(b => b.Name.ToLower().Contains(filter.ToLower()));
            }

            var barDTOs = await bars
                .Select(b => this.barMapper.MapToBarDTO(b))
                .ToListAsync();

            return barDTOs;
        }

        public async Task<IList<BarDTO>> ListAllBarsAsync(int skip, int pageSize, string searchValue, string orderBy, string orderDirection)
        {
            var bars = this.context.Bars
                .Include(bar => bar.BarCocktails)
                    .ThenInclude(bc => bc.Cocktail)
                .Include(bar => bar.City)
                .Where(bar => bar.IsDeleted == false);



            if (!string.IsNullOrEmpty(orderBy))
            {
                if (string.IsNullOrEmpty(orderDirection) || orderDirection == "asc")
                {
                    bars = bars.OrderBy(orderBy);
                }
                else
                {
                    bars = bars.OrderByDescending(orderBy);
                }
            }

            if (!string.IsNullOrEmpty(searchValue))
            {
                searchValue = searchValue.ToLower();

                bars = bars
                     .Where(bar => bar.Name.ToLower()
                     .Contains(searchValue.ToLower()));
            }

            bars = bars
                .Skip(skip)
                .Take(pageSize);

            var barDTOs = await bars.Select(bar => barMapper.MapToBarDTO(bar)).ToListAsync();

            return barDTOs;
        }

        public int GetAllBarsCount()
        {
            return this.context.Bars.Where(bar => !bar.IsDeleted).Count();
        }

        public int GetAllFilteredBarsCount(string searchValue)
        {
            if (!string.IsNullOrEmpty(searchValue))
            {
                searchValue = searchValue.ToLower();

                var bars = this.context.Bars
                     .Where(bar => bar.Name.ToLower()
                     .Contains(searchValue.ToLower()));

                return bars.Count();
            }
            return this.context.Bars.Where(bar => !bar.IsDeleted).Count();
        }

    }
}
