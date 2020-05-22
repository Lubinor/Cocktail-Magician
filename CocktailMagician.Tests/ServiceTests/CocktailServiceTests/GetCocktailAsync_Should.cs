using CocktailMagician.Data;
using CocktailMagician.Services;
using CocktailMagician.Services.DTOs;
using CocktailMagician.Services.Mappers;
using CocktailMagician.Services.Provider.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.ServiceTests.CocktailServiceTests
{
    [TestClass]
    public class GetCocktailAsync_Should
    {
        [TestMethod]
        public async Task ReturnCocktail_WhenFound()
        {
            //Arrange
            var mockDateTimeProvider = new Mock<IDatetimeProvider>();
            var mockMapper = new Mock<CocktailMapper>();
            var mockIngredientMapper = new Mock<IngredientMapper>();
            var options = Utils.GetOptions(nameof(ReturnCocktail_WhenFound));
            var expected = new CocktailDTO
            {
                Id = 2,
                Name = "Gin Fizz",
                AverageRating = 6.5,
                Ingredients = new List<IngredientDTO>
                    {
                        new IngredientDTO
                        {
                            Name = "Dry Gin"
                        },
                        new IngredientDTO
                        {
                            Name = "Tonic"
                        }
                    },
                Bars = new List<BarDTO>
                    {
                        new BarDTO
                        {
                            Name = "The Bar"
                        }
                    }
            };
            Utils.GetInMemoryTwoCocktails(options);
            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new CocktailService(mockDateTimeProvider.Object, mockMapper.Object,
                    mockIngredientMapper.Object, assertContext);
                var result = await sut.GetCocktailAsync(2);

                Assert.AreEqual(expected.Id, result.Id);
                Assert.AreEqual(expected.Name, result.Name);
                Assert.AreEqual(expected.AverageRating, result.AverageRating);
                Assert.AreEqual(expected.Ingredients.ToList().Count, result.Ingredients.ToList().Count);
                CollectionAssert.AreEqual(expected.Ingredients.ToList(), result.Ingredients.ToList());
                //CollectionAssert.AreEqual(expected.Bars.ToList(), result.Bars.ToList());
            }
        }
    }
}
