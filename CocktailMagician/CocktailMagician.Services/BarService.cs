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
using System.Transactions;

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
            this.barMapper = barMapper ?? throw new ArgumentNullException(nameof(barMapper)); ;
        }
        public async Task<ICollection<BarDTO>> GetAllBarsAsync()
        {
            var bars = this.context.Bars
                .Include(b => b.BarCocktails)
                .Where(b => !b.IsDeleted);

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
                throw new ArgumentNullException();
            }

            var bar = this.barMapper.MapToBar(barDTO);

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

            bar = this.barMapper.MapToBar(barDTO);

            this.context.Bars.Update(bar);
            await this.context.SaveChangesAsync();

            var updatedBarDTO = this.barMapper.MapToBarDTO(bar);

            return updatedBarDTO;
        }

        public async Task<bool> DeletBarAsync(int id)
        {
            var bar = await this.context.Bars
                .Include(b => b.BarCocktails)
                .FirstOrDefaultAsync(b => !b.IsDeleted && b.Id == id);

            if (bar == null)
            {
                return false;
            }

            bar.IsDeleted = true;

            foreach (var cocktail in bar.BarCocktails)
            {
                cocktail.Cocktail.IsDeleted = true;
            }

            foreach (var review in bar.BarReviews)
            {
                review.IsDeleted = true;
            }

            this.context.Bars.Update(bar);
            await this.context.SaveChangesAsync();

            return true;
        }
    }
}
