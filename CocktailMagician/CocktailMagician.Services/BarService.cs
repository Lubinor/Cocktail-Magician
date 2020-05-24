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
        //TODO make a separate method that accepts collection - but it will not be Async. Which is better?
        public async Task<ICollection<BarDTO>> GetAllBarsAsync(string sortMethod = null)
        {
            var bars = this.context.Bars
                .Include(b => b.BarCocktails)
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

            return barDTOs;
        }

        public async Task<BarDTO> GetBarAsync(int id)
        {
            var bar = await this.context.Bars
                .Include(b => b.BarCocktails)
                .FirstOrDefaultAsync(b => !b.IsDeleted && b.Id == id);

            if (bar == null)
            {
                return null;
            }

            var barDTO = this.barMapper.MapToBarDTO(bar);

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
            bar.CreatedOn = dateTimeProvider.GetDateTime();

            this.context.Bars.Add(bar);
            await this.context.SaveChangesAsync();

            var newBarDTO = this.barMapper.MapToBarDTO(bar);

            return newBarDTO;
        }

        public async Task<BarDTO> UpdateBarAsync(int id, BarDTO barDTO)
        {
            var bar = await this.context.Bars
                .Include(b => b.BarCocktails)
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

            //Does it make sense? Or should I dig into the context again?
            var updatedBarDTO = this.barMapper.MapToBarDTO(bar);

            return updatedBarDTO;
        }

        public async Task<bool> DeletBarAsync(int id)
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
    }
}
