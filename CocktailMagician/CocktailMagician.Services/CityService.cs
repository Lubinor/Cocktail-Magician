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

        public CityService(IDateTimeProvider dateTimeProvider, CocktailMagicianContext context, ICityMapper cityMapper)
        {
            this.dateTimeProvider = dateTimeProvider ?? throw new ArgumentNullException(nameof(dateTimeProvider));
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.cityMapper = cityMapper ?? throw new ArgumentNullException(nameof(cityMapper));
        }

        public async Task<ICollection<CityDTO>> GetAllCitiesAsync()
        {
            var cities = this.context.Cities
                .Include(c => c.Bars)
                .Where(c => !c.IsDeleted);

            var cityDTOs = await cities
                .Select(c => this.cityMapper.CityToCityDTO(c))
                .ToListAsync();

            return cityDTOs;
        }

        public async Task<CityDTO> GetCityAsync(int id)
        {
            var city = await this.context.Cities
                .Include(c => c.Bars)
                .Where(c => !c.IsDeleted)
                .FirstOrDefaultAsync();

            if (city == null)
            {
                return null;
            }

            var cityDTO = this.cityMapper.CityToCityDTO(city);

            return cityDTO;
        }

        public async Task<CityDTO> CreateCityAsync(CityDTO cityDTO)
        {
            if (cityDTO == null)
            {
                return null;
            }

            var city = cityMapper.CityDTOtoCity(cityDTO);

            this.context.Cities.Add(city);
            await this.context.SaveChangesAsync();

            var newCityDTO = cityMapper.CityToCityDTO(city);

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

            city = cityMapper.CityDTOtoCity(cityDTO);

            this.context.Cities.Update(city);
            await this.context.SaveChangesAsync();

            var updatedCityDTO = cityMapper.CityToCityDTO(city);

            return updatedCityDTO;
        }

        public async Task<bool> DeleteCityAsync(int id)
        {
            var city = await this.context.Cities
                .Include(c => c.Bars)
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
