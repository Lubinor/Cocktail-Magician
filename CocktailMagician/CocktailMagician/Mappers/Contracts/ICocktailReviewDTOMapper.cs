using CocktailMagician.Services.DTOs;
using CocktailMagician.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Web.Mappers.Contracts
{
    public interface ICocktailReviewDTOMapper
    {
        public CocktailReviewViewModel MapToVMFromDTO(CocktailReviewDTO cocktailReviewDTO);
        public CocktailReviewDTO MapToDTOFromVM(CocktailReviewViewModel cocktailReviewVM);
        public CocktailReviewDTO MapToDTOFromVM(CreateCocktailReviewViewModel createCocktailReviewVM);
    }
}
