using CocktailMagician.Services.DTOs;
using CocktailMagician.Web.Models;

namespace CocktailMagician.Web.Mappers.Contracts
{
    interface ICocktailDTOMapper
    {
        public CocktailDTO MapToDTOFromVM(CocktailViewModel coctailVM);
        public CocktailViewModel MapToCocktail(CocktailDTO coctailDTO);
    }
}
