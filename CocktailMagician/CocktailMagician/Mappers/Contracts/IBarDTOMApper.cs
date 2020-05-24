using CocktailMagician.Services.DTOs;
using CocktailMagician.Web.Models;

namespace CocktailMagician.Web.Mappers.Contracts
{
    public interface IBarDTOMApper
    {
        public BarViewModel MapToVMFromDTO(BarDTO barDTO);
        public BarDTO MapToDTOFromVM(BarViewModel barVM);
    }
}
