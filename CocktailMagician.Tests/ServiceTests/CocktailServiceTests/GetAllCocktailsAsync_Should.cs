using CocktailMagician.Data;
using CocktailMagician.Services;
using CocktailMagician.Services.DTOs;
using CocktailMagician.Services.Mappers;
using CocktailMagician.Services.Providers.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.ServiceTests.CocktailServiceTests
{
    [TestClass]
    public class GetAllCocktailsAsync_Should
    {
        [TestMethod]
        public async Task ReturnCorrectCocktails()
        {
            //Arrange
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockMapper = new Mock<CocktailMapper>();
            var mockIngMapper = new Mock<IngredientMapper>();
            var options = Utils.GetOptions(nameof(ReturnCorrectCocktails));
            var expected = new List<CocktailDTO>
            {
                new CocktailDTO
                {
                    Id = 1,
                    Name = "Bloody Mary",
                    AverageRating = 5.5,
                    Ingredients = new List<IngredientDTO>
                    {
                        new IngredientDTO
                        {
                            //Id = 1,
                            Name = "Vodka"
                        },
                        new IngredientDTO
                        {
                            //Id = 2,
                            Name = "Tomato Juice"
                        }
                    },
                    Bars = new List<BarDTO>
                    {
                        new BarDTO
                        {
                            //Id = 1,
                            Name = "The Bar"
                        }
                    }
                },
                new CocktailDTO
                {
                    Id = 2,
                    Name = "Gin Fizz",
                    AverageRating = 6.5,
                    Ingredients = new List<IngredientDTO>
                    {
                        new IngredientDTO
                        {
                            //Id = 3,
                            Name = "Dry Gin"
                        },
                        new IngredientDTO
                        {
                            //Id = 4,
                            Name = "Tonic"
                        }
                    },
                    Bars = new List<BarDTO>
                    {
                        new BarDTO
                        {
                            //Id = 1,
                            Name = "The Bar"
                        }
                    }
                }
            };
            Utils.GetInMemoryTwoCocktails(options);
            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new CocktailService(mockDateTimeProvider.Object, mockMapper.Object,
                    mockIngMapper.Object, assertContext);
                var result = (await sut.GetAllCocktailssAsync()).ToList();
                Assert.AreEqual(expected.Count, result.Count);
                for (int i = 0; i < expected.Count; i++)
                {
                    Assert.AreEqual(expected[i].Id, result[i].Id);
                    Assert.AreEqual(expected[i].Name, result[i].Name);
                    Assert.AreEqual(expected[i].AverageRating, result[i].AverageRating);
                    Assert.AreEqual(expected[i].Ingredients.Count, result[i].Ingredients.Count);
                    Assert.AreEqual(expected[i].Bars.Count, result[i].Bars.Count);
                }
                //CollectionAssert.AreEqual(expected, result);
            }
        }
    }
}
