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
    public class CityService : ICityService
    {
        private readonly IDateTimeProvider dateTimeProvider;
        private readonly CocktailMagicianContext context;
        private readonly ICityMapper cityMapper;
        private readonly IBarMapper barMapper;

        public CityService(IDateTimeProvider dateTimeProvider, CocktailMagicianContext context, ICityMapper cityMapper, IBarMapper barMapper)
        {
            this.dateTimeProvider = dateTimeProvider ?? throw new ArgumentNullException(nameof(dateTimeProvider));
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.cityMapper = cityMapper ?? throw new ArgumentNullException(nameof(cityMapper));
            this.barMapper = barMapper ?? throw new ArgumentNullException(nameof(barMapper));
        }

        public async Task<ICollection<CityDTO>> GetAllCitiesAsync()
        {
            var cities = this.context.Cities
                .Include(c => c.Bars)
                .Where(c => !c.IsDeleted);

            var cityDTOs = await cities
                .Select(c => this.cityMapper.MapToCityDTO(c))
                .ToListAsync();

            return cityDTOs;
        }

        public async Task<CityDTO> GetCityAsync(int id)
        {
            var city = await this.context.Cities
                .Include(c => c.Bars)
                .Where(c => !c.IsDeleted && c.Id == id)
                .FirstOrDefaultAsync();

            if (city == null)
            {
                return null;
            }

            var cityDTO = this.cityMapper.MapToCityDTO(city);

            cityDTO.Bars = city.Bars
                .Where(bar => !bar.IsDeleted)
                .Select(bar => barMapper.MapToBarDTO(bar))
                .ToList();

            return cityDTO;
        }

        public async Task<CityDTO> CreateCityAsync(CityDTO cityDTO)
        {
            if (cityDTO == null)
            {
                return null;
            }

            var city = cityMapper.MapToCity(cityDTO);
            city.CreatedOn = dateTimeProvider.GetDateTime();

            this.context.Cities.Add(city);
            await this.context.SaveChangesAsync();

            var newCityDTO = cityMapper.MapToCityDTO(city);

            return newCityDTO;
        }

        public async Task<CityDTO> UpdateCityAsync(int id, CityDTO cityDTO)
        {
            var city = await this.context.Cities
                .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);

            if (city == null)
            {
                return null;
            }

            city.Name = cityDTO.Name; //update manually, instead of replacing the whole object, to avoid overwriting collections?

            this.context.Cities.Update(city);
            await this.context.SaveChangesAsync();

            var updatedCityDTO = cityMapper.MapToCityDTO(city);

            return updatedCityDTO;
        }

        public async Task<bool> DeleteCityAsync(int id)
        {
            var city = await this.context.Cities
                .Include(c => c.Bars)
                    .ThenInclude(b => b.BarReviews)
                .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);

            if (city == null)
            {
                return false;
            }

            city.IsDeleted = true;

            foreach (var bar in city.Bars)
            {
                bar.IsDeleted = true;
                this.context.Bars.Update(bar);

                foreach (var review in bar.BarReviews)
                {
                    review.IsDeleted = true;
                    this.context.BarsUsersReviews.Update(review);
                }
            }
            this.context.Cities.Update(city);
            await this.context.SaveChangesAsync();

            return true;
        }
    }
}
