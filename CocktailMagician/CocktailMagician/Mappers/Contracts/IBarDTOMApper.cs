using CocktailMagician.Services.DTOs;
using CocktailMagician.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Web.Mappers.Contracts
{
    public interface IBarDTOMApper
    {
        public BarViewModel MapToVMFromDTO(BarDTO barDTO);
        public BarDTO MapToDTOFromVM(BarViewModel barVM);
    }
}
