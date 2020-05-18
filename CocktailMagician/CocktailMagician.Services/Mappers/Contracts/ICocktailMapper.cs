using CocktailMagician.Models;
using CocktailMagician.Services.DTOs;

namespace CocktailMagician.Services.Mappers.Contracts
{
    public interface ICocktailMapper
    {
        public CocktailDTO CocktailToCocktailDTO(Cocktail cocktail);
        public Cocktail CocktailDTOtoCocktail(CocktailDTO cocktailDTO);
    }
}
