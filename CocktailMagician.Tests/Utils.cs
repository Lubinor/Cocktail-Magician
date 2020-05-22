using CocktailMagician.Data;
using CocktailMagician.Models;
using CocktailMagician.Services.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

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
        public static void GetInMemoryThreeIngredients(DbContextOptions<CocktailMagicianContext> options)
        {
            var cocktail = new Cocktail { Id = 1, Name = "Bloody Mary" };
            var ingredientcocktails = new List<IngredientsCocktails>
            {
                new IngredientsCocktails
                {
                    CocktailId = 1,
                    IngredientId = 1,
                },
                new IngredientsCocktails
                {
                    CocktailId = 1,
                    IngredientId = 2
                }
            };
            var ingredients = new List<Ingredient>
            {
                new Ingredient
                {
                    Id = 1,
                    Name = "Vodka",
                    IsDeleted = false,
                    IngredientsCocktails = new List<IngredientsCocktails>
                    {
                        ingredientcocktails[0]
                    }
                },
                new Ingredient
                {
                    Id = 2,
                    Name = "Tomato Juice",
                    IsDeleted = false,
                    IngredientsCocktails = new List<IngredientsCocktails>
                    {
                        ingredientcocktails[1]
                    }
                },
                new Ingredient
                {
                    Id = 3,
                    Name = "Tabasco",
                    IsDeleted = false
                }
            };
            using (var arrangeContext = new CocktailMagicianContext(options))
            {
                arrangeContext.Cocktails.Add(cocktail);
                arrangeContext.Ingredients.AddRange(ingredients);
                arrangeContext.IngredientsCocktails.AddRange(ingredientcocktails);
                arrangeContext.SaveChanges();
            }
        }
        public static void GetInMemoryTwoCocktails(DbContextOptions<CocktailMagicianContext> options)
        {

            var ingredientCocktails = new List<IngredientsCocktails>
            {
                new IngredientsCocktails
                {
                    CocktailId = 1,
                    IngredientId = 1
                },
                new IngredientsCocktails
                {
                    CocktailId = 1,
                    IngredientId = 2
                },
                new IngredientsCocktails
                {
                    CocktailId = 2,
                    IngredientId = 3
                },
                new IngredientsCocktails
                {
                    CocktailId = 2,
                    IngredientId = 4
                }
            };
            var ingredients = new List<Ingredient>
            {
                new Ingredient
                {
                    Id = 1,
                    Name = "Vodka",
                    IsDeleted = false,
                    IngredientsCocktails = new List<IngredientsCocktails>
                    {
                        ingredientCocktails[0]
                    }
                },
                new Ingredient
                {
                    Id = 2,
                    Name = "Tomato Juice",
                    IsDeleted = false,
                    IngredientsCocktails = new List<IngredientsCocktails>
                    {
                        ingredientCocktails[1]
                    }
                },
                new Ingredient
                {
                    Id = 3,
                    Name = "Dry Gin",
                    IsDeleted = false,
                    IngredientsCocktails = new List<IngredientsCocktails>
                    {
                        ingredientCocktails[2]
                    }
                },
                new Ingredient
                {
                    Id = 4,
                    Name = "Tonic",
                    IsDeleted = false,
                    IngredientsCocktails = new List<IngredientsCocktails>
                    {
                        ingredientCocktails[3]
                    }
                }
            };
            var cocktails = new List<Cocktail>
            {
                new Cocktail
                {
                    Id = 1,
                    Name = "Bloody Mary",
                    AverageRating = 5.5,
                    IsDeleted = false,
                    IngredientsCocktails = new List<IngredientsCocktails>
                    {
                        ingredientCocktails[0],ingredientCocktails[1]
                    }
                },
                new Cocktail
                {
                    Id = 2,
                    Name = "Gin Fizz",
                    AverageRating = 6.5,
                    IsDeleted = false,
                    IngredientsCocktails = new List<IngredientsCocktails>
                    {
                        ingredientCocktails[2],ingredientCocktails[3]
                    }
                }
            };
            var barCocktails = new List<BarsCocktails>
            {
                new BarsCocktails
                {
                    BarId = 1,
                    CocktailId = 1
                },
                new BarsCocktails
                {
                    BarId = 1,
                    CocktailId = 2
                }
            };
            var bar = new Bar
            {
                Id = 1,
                Name = "The Bar",
                BarCocktails = new List<BarsCocktails>
                {
                    barCocktails[0], barCocktails[1]
                }

            };
            using (var arrangeContext = new CocktailMagicianContext(options))
            {
                arrangeContext.Cocktails.AddRange(cocktails);
                arrangeContext.Ingredients.AddRange(ingredients);
                arrangeContext.IngredientsCocktails.AddRange(ingredientCocktails);
                arrangeContext.BarsCocktails.AddRange(barCocktails);
                arrangeContext.Bars.Add(bar);
                arrangeContext.SaveChanges();
            }
        }
    }
}
