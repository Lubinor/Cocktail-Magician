using CocktailMagician.Data;
using CocktailMagician.Services;
using CocktailMagician.Services.Contracts;
using CocktailMagician.Services.DTOs;
using CocktailMagician.Services.Mappers;
using CocktailMagician.Services.Mappers.Contracts;
using CocktailMagician.Services.Provider;
using CocktailMagician.Services.Provider.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.ServiceTests.IngredientServiceTests
{
    [TestClass]
    public class GetIngredientAsync_Should
    {
        [TestMethod]
        public async Task ReturnIngredient_WhenFound()
        {
            //Arrange
            var mockDatetimeProvider = new Mock<IDatetimeProvider>();
            var mockMapper = new Mock<IngredientMapper>();
            var mockCocktailMapper = new Mock<CocktailMapper>();
            var options = Utils.GetOptions(nameof(ReturnIngredient_WhenFound));
            var expected = new IngredientDTO
            {
                Id = 1,
                Name = "Vodka"
            };
            Utils.GetInMemoryThreeIngredients(options);

            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new IngredientService(mockDatetimeProvider.Object,mockMapper.Object,
                    mockCocktailMapper.Object, assertContext);
                var result = await sut.GetIngredientAsync(1);
                Assert.AreEqual(expected.Id, result.Id);
                Assert.AreEqual(expected.Name, result.Name);
            }

        }
        [TestMethod]
        public async Task ReturnNull_WhenNotFound()
        {
            //Arrange
            var mockDatetimeProvider = new Mock<IDatetimeProvider>();
            var mockMapper = new Mock<IngredientMapper>();
            var mockCocktailMapper = new Mock<CocktailMapper>();
            var options = Utils.GetOptions(nameof(ReturnNull_WhenNotFound));
            Utils.GetInMemoryThreeIngredients(options);

            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new IngredientService(mockDatetimeProvider.Object, mockMapper.Object,
                    mockCocktailMapper.Object, assertContext);
                var result = await sut.GetIngredientAsync(4);
                Assert.IsNull(result);
            }
        }
    }
}
