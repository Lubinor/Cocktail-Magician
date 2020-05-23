using CocktailMagician.Services.DTOs;
using CocktailMagician.Web.Models;

namespace CocktailMagician.Web.Mappers.Contracts
{
    interface IIngredientDTOMapper
    {
        public IngredientDTO MapToDTOFromVM(IngredientViewModel ingredientVM);
        public IngredientViewModel MapToVMFromDTO(IngredientDTO ingredientDTO);
    }
}
