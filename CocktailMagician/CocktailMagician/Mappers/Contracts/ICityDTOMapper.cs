using CocktailMagician.Services.DTOs;
using CocktailMagician.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Web.Mappers.Contracts
{
    public interface ICityDTOMapper
    {
        public CityViewModel MapToVMFromDTO(CityDTO cityDTO);
        public CityDTO MapToDTOFromVM(CityViewModel cityVM);
    }
}
