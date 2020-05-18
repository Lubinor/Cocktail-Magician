using CocktailMagician.Models;
using CocktailMagician.Services.DTOs;

namespace CocktailMagician.Services.Mappers.Contracts
{
    public interface ICityMapper
    {
        public CityDTO CityToCityDTO(City city);
        public City CityDTOtoCity(CityDTO city);
    }
}
