using CocktailMagician.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CocktailMagician.Services.Contracts
{
    public interface ICityService
    {
        Task<ICollection<CityDTO>> GetAllCitiesAsync();
        Task<CityDTO> GetCityAsync(int id);
        Task<CityDTO> CreateCityAsync(CityDTO cityDTO);
        Task<CityDTO> UpdateCityAsync(int id, CityDTO cityDTO);
        Task<bool> DeleteCityAsync(int id);
        Task<IList<CityDTO>> ListAllCitiesAsync(int skip, int pageSize, string searchValue,
                                                 string orderBy, string odrderDirection);
        int GetAllCitiesCount();
        int GetAllFilteredCitiesCount(string searchValue);
    }
}
