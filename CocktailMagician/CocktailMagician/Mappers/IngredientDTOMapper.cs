using CocktailMagician.Services.DTOs;
using CocktailMagician.Web.Mappers.Contracts;
using CocktailMagician.Web.Models;
using System.Linq;

namespace CocktailMagician.Web.Mappers
{
    public class IngredientDTOMapper : IIngredientDTOMapper
    {
        public IngredientDTOMapper()
        {

        }
        public IngredientDTO MapToDTOFromVM(IngredientViewModel ingredientVM)
        {
            if (ingredientVM == null)
            {
                return null;
            }
            var ingredientDTO = new IngredientDTO
            {
                Name = ingredientVM.Name
            };
            return ingredientDTO;
        }

        public IngredientViewModel MapToVMFromDTO(IngredientDTO ingredientDTO)
        {
            if (ingredientDTO == null)
            {
                return null;
            }
            var ingredientVM = new IngredientViewModel
            {
                Name = ingredientDTO.Name,
                Cocktails = ingredientDTO.CocktailDTOs.Select(c => new CocktailViewModel
                {
                    Name = c.Name,
                    AverageRating = c.AverageRating
                }).ToList()
            };

            return ingredientVM;
        }
    }
}
