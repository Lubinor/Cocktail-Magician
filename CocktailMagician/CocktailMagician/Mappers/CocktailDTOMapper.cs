using CocktailMagician.Services.DTOs;
using CocktailMagician.Web.Mappers.Contracts;
using CocktailMagician.Web.Models;
using System.Linq;

namespace CocktailMagician.Web.Mappers
{
    public class CocktailDTOMapper : ICocktailDTOMapper
    {
        public CocktailDTOMapper()
        {

        }
        public CocktailViewModel MapToVMFromDTO(CocktailDTO cocktailDTO)
        {
            if (cocktailDTO == null)
            {
                return null;
            }
            var cocktailVM = new CocktailViewModel
            {
                Name = cocktailDTO.Name,
                AverageRating = cocktailDTO.AverageRating,
                Bars = cocktailDTO.Bars.Select(b => new BarViewModel
                {
                    Name = b.Name,
                    //Address = b.Address,
                    CityName = b.CityName,
                    //Phone = b.Phone,
                    AverageRating = b.AverageRating
                }).ToList(),
                Ingredients = cocktailDTO.Ingredients.Select(i => new IngredientViewModel
                {
                    Name = i.Name
                }).ToList()
            };
            return cocktailVM;
        }

        public CocktailDTO MapToDTOFromVM(CocktailViewModel coctailVM)
        {
            if (coctailVM == null)
            {
                return null;
            }
            var cocktailDTO = new CocktailDTO
            {
                Name = coctailVM.Name,
                Ingredients = coctailVM.Ingredients.Select(i => new IngredientDTO
                {
                    Name = i.Name
                }).ToList()
            };

            return cocktailDTO;
        }
    }
}
