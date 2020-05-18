using CocktailMagician.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
