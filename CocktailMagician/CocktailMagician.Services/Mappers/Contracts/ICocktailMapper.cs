using CocktailMagician.Models;
using CocktailMagician.Services.DTOs;

namespace CocktailMagician.Services.Mappers.Contracts
{
    public interface ICocktailMapper
    {public CocktailDTO MapToCocktailDTO(Cocktail coctail);
        public Cocktail MapToCocktail(CocktailDTO coctailDTO);
        
    }
}
