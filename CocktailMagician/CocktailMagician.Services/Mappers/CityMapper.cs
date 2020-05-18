using CocktailMagician.Models;
using CocktailMagician.Services.DTOs;
using CocktailMagician.Services.Mappers.Contracts;
using System.Linq;

namespace CocktailMagician.Services.Mappers
{
    public class CityMapper : ICityMapper
    {

        public CityMapper()
        {
        }

        public CityDTO CityToCityDTO(City city)
        {
            CityDTO cityDTO = new CityDTO
            {
                Id = city.Id,
                Name = city.Name,
                Bars = city.Bars
                            .Select(bar => new BarDTO { Id = bar.Id, Name = bar.Name })
                            .ToList(),
                CreatedOn = city.CreatedOn,
                IsDeleted = city.IsDeleted
            };

            return cityDTO;
        }
        public City CityDTOtoCity(CityDTO cityDTO)
        {
            City city = new City
            {
                Name = cityDTO.Name,
                CreatedOn = cityDTO.CreatedOn,
                IsDeleted = cityDTO.IsDeleted
            };

            return city;
        }
    }
}
