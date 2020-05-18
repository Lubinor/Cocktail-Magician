using CocktailMagician.Data;
using CocktailMagician.Models;
using Microsoft.EntityFrameworkCore;

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
            var bar = new Bar { Id = 1, Name = "Lorka" };
            //var cocktail = new Cocktail { Id = 1, Name = "Bloody Mary" };
            //var ingredient1 = new Ingredient { Id = 1, Name = "Vodka" };
            //var ingredient2 = new Ingredient { Id = 2, Name = "Tomato juice" };
            //var ingredient3 = new Ingredient { Id = 3, Name = "Tabasco" };

            //cocktail.Ingredients.Add(new IngredientsCocktails { IngredientId = 1, CocktailId = 1 });
            //cocktail.Ingredients.Add(new IngredientsCocktails { IngredientId = 2, CocktailId = 1 });
            //cocktail.Ingredients.Add(new IngredientsCocktails { IngredientId = 3, CocktailId = 1 });

            //bar.Cocktails.Add(new BarsCocktails { BarId = bar.Id, CocktailId = cocktail.Id });


            var city = new City
            {
                Id = 1,
                Name = "Sofia",
            };

            city.Bars.Add(bar);

            return city;
        }
    }
}
