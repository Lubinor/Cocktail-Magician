using CocktailMagician.Services.DTOs;
using CocktailMagician.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Web.Mappers.Contracts
{
    public interface IBarReviewDTOMapper
    {
        public BarReviewViewModel MapToVMFromDTO(BarReviewDTO barReviewDTO);
        public BarReviewDTO MapToDTOFromVM(BarReviewViewModel barReviewVM);
    }
}
