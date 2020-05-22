﻿using CocktailMagician.Models;
using CocktailMagician.Services.DTOs;
using CocktailMagician.Services.Mappers.Contracts;
using System.Linq;

namespace CocktailMagician.Services.Mappers
{
    public class BarMapper : IBarMapper
    {
        private readonly ICocktailMapper cocktailMapper;

        public BarMapper(ICocktailMapper cocktailMapper)
        {
            this.cocktailMapper = cocktailMapper;
        }

        public BarDTO MapToBarDTO(Bar bar)
        {
            BarDTO barDTO = new BarDTO();

            barDTO.Id = bar.Id;
            barDTO.Name = bar.Name;
            barDTO.CityId = bar.CityId;
            barDTO.CityName = bar.City.Name;
            barDTO.Address = bar.Address;
            barDTO.Phone = bar.Phone;
            barDTO.AverageRating = bar.AverageRating;

            var barCocktails = bar.Cocktails
                                    .Select(b => b.Cocktail)
                                    .ToList();

            barDTO.Cocktails = barCocktails
                                    .Select(c => new CocktailDTO 
                                    {
                                        Id = c.Id,
                                        Name = c.Name,
                                        AverageRating = c.AverageRating
                                    })
                                    .ToList();

            return barDTO;
        }
        public Bar MapToBar(BarDTO barDTO)
        {
            Bar bar = new Bar();
            bar.Name = barDTO.Name;
            bar.CityId = barDTO.CityId;
            bar.Address = barDTO.Address;
            bar.Phone = barDTO.Phone;
            bar.AverageRating = barDTO.AverageRating;

            var barCocktails = barDTO.Cocktails
                                    .Select(c => cocktailMapper
                                    .MapToCocktail(c))
                                    .ToList();

            bar.Cocktails = barCocktails
                                    .Select(x => new BarsCocktails { BarId = barDTO.Id, CocktailId = x.Id })
                                    .ToList();

            return bar;
        }
    }
}
