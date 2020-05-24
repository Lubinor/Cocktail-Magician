using CocktailMagician.Services.DTOs;
using CocktailMagician.Web.Models;

namespace CocktailMagician.Web.Mappers.Contracts
{
    public interface ICocktailDTOMapper
    {
        public CocktailViewModel MapToVMFromDTO(CocktailDTO coctailDTO);
        public CocktailDTO MapToDTOFromVM(CocktailViewModel coctailVM);
    }
}
