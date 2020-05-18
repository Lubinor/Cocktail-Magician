using CocktailMagician.Models;
using CocktailMagician.Services.DTOs;
using CocktailMagician.Services.Mappers.Contracts;

namespace CocktailMagician.Services.Mappers
{
    public class CocktailMapper : ICocktailMapper
    {
        //TODO just a placeholder to get my stuff to work
        public CocktailDTO CocktailToCocktailDTO(Cocktail cocktail)
        {
            CocktailDTO cocktailDTO = new CocktailDTO();

            return cocktailDTO;
        }
        public Cocktail CocktailDTOtoCocktail(CocktailDTO cocktailDTO)
        {
            Cocktail cocktail = new Cocktail();

            return cocktail;
        }
    }
}
