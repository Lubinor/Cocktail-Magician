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
        public IngredientViewModel MapToVMFromDTO(IngredientDTO ingredientDTO)
        {
            if (ingredientDTO == null)
            {
                return null;
            }
            var ingredientVM = new IngredientViewModel
            {
                Id = ingredientDTO.Id,
                Name = ingredientDTO.Name,
                Cocktails = ingredientDTO.CocktailDTOs.Select(c => new CocktailViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    AverageRating = c.AverageRating
                }).ToList()
            };

            return ingredientVM;
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
        public IngredientDTO MapToDTOFromVM(EditIngredientViewModel editIngredientVM)
        {
            if (editIngredientVM == null)
            {
                return null;
            }
            var ingredientDTO = new IngredientDTO
            {
                Id = editIngredientVM.Id,
                Name = editIngredientVM.Name
            };

            return ingredientDTO;
        }
    }
}
