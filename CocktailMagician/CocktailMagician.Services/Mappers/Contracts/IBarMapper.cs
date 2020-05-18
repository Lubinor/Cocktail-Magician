using CocktailMagician.Models;
using CocktailMagician.Services.DTOs;

namespace CocktailMagician.Services.Mappers.Contracts
{
    public interface IBarMapper
    {
        public BarDTO BarToBarDTO(Bar bar);
        public Bar BarDTOtoBar(BarDTO barDTO);
    }
}
