using CocktailMagician.Data;
using CocktailMagician.Models;
using CocktailMagician.Services.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace CocktailMagician.Tests
{
    public static class Utils
    {
        public static DbContextOptions<CocktailMagicianContext> GetOptions(string databaseName)
        {
            return new DbContextOptionsBuilder<CocktailMagicianContext>()
                .UseInMemoryDatabase(databaseName)
                .Options;
        }

        public static City ReturnOneCity(DbContextOptions<CocktailMagicianContext> options)
        {
            var bar = new Bar { Id = 1, Name = "Lorka", CityId = 1 };
            var city = new City
            {
                Id = 1,
                Name = "Sofia",
            };

            city.Bars.Add(bar);

            return city;
        }

        public static CityDTO ReturnOneCityDTO(DbContextOptions<CocktailMagicianContext> options)
        {
            var cityDTO = new CityDTO { Id = 1, Name = "Sofia" };

            return cityDTO;
        }

        public static Bar ReturnOneBar(DbContextOptions<CocktailMagicianContext> options)
        {
            var city = new City { Id = 1, Name = "Sofia" };

            var cocktail = new Cocktail { Id = 1, Name = "Bloody Mary" };
            //var ingredient1 = new Ingredient { Id = 1, Name = "Vodka" };
            //var ingredient2 = new Ingredient { Id = 2, Name = "Tomato juice" };
            //var ingredient3 = new Ingredient { Id = 3, Name = "Tabasco" };

            //cocktail.Ingredients.Add(new IngredientsCocktails { IngredientId = 1, CocktailId = 1 });
            //cocktail.Ingredients.Add(new IngredientsCocktails { IngredientId = 2, CocktailId = 1 });
            //cocktail.Ingredients.Add(new IngredientsCocktails { IngredientId = 3, CocktailId = 1 });

            var bar = new Bar 
            { 
                Id = 1, 
                Name = "Lorka", 
                CityId = 1, 
                City = city, 
                Address = "Shishman str.", 
                Phone = "0888 888 888",  
                AverageRating = 3.5,
            };

            bar.Cocktails.Add(new BarsCocktails { BarId = bar.Id, CocktailId = cocktail.Id, Cocktail = cocktail });

            return bar;
        }

        public static BarDTO ReturnOneBarDTO(DbContextOptions<CocktailMagicianContext> options)
        {
            var barDTO = new BarDTO
            {
                Id = 1,
                Name = "Lorka",
                CityId = 1,
                CityName = "Sofia",
                Address = "Shishman str.",
                Phone = "0888 888 888",
                AverageRating = 3.5,
            };

            return barDTO;
        }
    }
}
