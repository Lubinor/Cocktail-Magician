using CocktailMagician.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CocktailMagician.Services.Contracts
{
    public interface ICocktailService
    {
        Task<ICollection<CocktailDTO>> GetAllCocktailssAsync();
        Task<CocktailDTO> GetCocktailAsync(int id);
        Task<CocktailDTO> CreateCocktailAsync(CocktailDTO coctailDTO);
        Task<CocktailDTO> UpdateCocktailAsync(int id, CocktailDTO coctailDTO);
        Task<bool> DeleteCocktailAsync(int id);
        Task<IList<CocktailDTO>> ListAllCocktailsAsync(int skip, int pageSize, string searchValue,
            string orderBy, string orderDirection);
        int GetAllCocktailsCount();
        int GetAllFilteredCocktailsCount(string searchValue);
    }
}
