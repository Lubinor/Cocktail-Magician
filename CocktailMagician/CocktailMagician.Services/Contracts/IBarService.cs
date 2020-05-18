using CocktailMagician.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CocktailMagician.Services.Contracts
{
    public interface IBarService
    {
        Task<ICollection<BarDTO>> GetAllBarsAsync();
        Task<BarDTO> GetBarAsync(int id);
        Task<BarDTO> CreateBarAsync(BarDTO barDTO);
        Task<BarDTO> UpdateBarAsync(int id, BarDTO barDTO);
        Task<bool> DeletBarAsync(int id);
    }
}
