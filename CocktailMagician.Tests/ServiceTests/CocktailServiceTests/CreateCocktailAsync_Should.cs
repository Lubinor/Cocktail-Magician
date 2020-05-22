using CocktailMagician.Data;
using CocktailMagician.Services;
using CocktailMagician.Services.DTOs;
using CocktailMagician.Services.Mappers;
using CocktailMagician.Services.Provider.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.ServiceTests.CocktailServiceTests
{
    [TestClass]
    public class CreateCocktailAsync_Should
    {
        [TestMethod]
        public async Task CreateCocktail_WhenParamsAreValid()
        {
            //Arrange
            var mockDateTimeProvider = new Mock<IDatetimeProvider>();
            var mockMapper = new Mock<CocktailMapper>();
            var mockIngMapper = new Mock<IngredientMapper>();
            var options = Utils.GetOptions(nameof(CreateCocktail_WhenParamsAreValid));
            var expected = new CocktailDTO
            {
                Name = "Mochito",
                Ingredients = new List<IngredientDTO>
                {
                    new IngredientDTO
                    {
                        Name = "White Rum"
                    },
                    new IngredientDTO
                    {
                        Name = "Soda"
                    }
                }
            };
            Utils.GetInMemoryTwoCocktails(options);
            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new CocktailService(mockDateTimeProvider.Object, mockMapper.Object,
                    mockIngMapper.Object, assertContext);
                var result = await sut.CreateCocktailAsync(expected);

                Assert.IsInstanceOfType(result, typeof(CocktailDTO));
            }
        }
    }
}
