using CocktailMagician.Data;
using CocktailMagician.Services;
using CocktailMagician.Services.DTOs;
using CocktailMagician.Services.Mappers;
using CocktailMagician.Services.Provider.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.ServiceTests.IngredientServiceTests
{
    [TestClass]
    public class UpdateIngredientAsync_Should
    {
        [TestMethod]
        public async Task UpdateIngredient_WhenParamsAreValid()
        {
            //Arrange
            var mockDateTiemProvider = new Mock<IDatetimeProvider>();
            var mockMapper = new Mock<IngredientMapper>();
            var mockCocktailMapper = new Mock<CocktailMapper>();
            var options = Utils.GetOptions(nameof(UpdateIngredient_WhenParamsAreValid));
            var newDTO = new IngredientDTO
            {
                Name = "Portocal Juice"
            };
            var expected = new IngredientDTO
            {
                Name = "Portocal Juice"
            };
            Utils.GetInMemoryThreeIngredients(options);

            //Act & Assert

            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new IngredientService(mockDateTiemProvider.Object, mockMapper.Object,
                    mockCocktailMapper.Object, assertContext);
                var result = await sut.UpdateIngredientAsync(2, newDTO);

                Assert.AreEqual(expected.Name, result.Name);
            }
        }
    }
}
