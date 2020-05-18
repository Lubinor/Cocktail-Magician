using CocktailMagician.Models;
using CocktailMagician.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Services.Mappers.Contracts
{
    public interface ICocktailMapper
    {
        public CocktailDTO MapToCocktailDTO(Cocktail coctail);
        public Cocktail MapToCocktail(CocktailDTO coctailDTO);
    }
}
