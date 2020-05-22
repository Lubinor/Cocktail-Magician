using CocktailMagician.Data;
using CocktailMagician.Services;
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
    public class DeleteCocktailAsync_Should
    {
        [TestMethod]
        public async Task DeleteCocktail_Should()
        {
            //Arrange
            var mockDateTimeprovider = new Mock<IDatetimeProvider>();
            var mockMapper = new Mock<CocktailMapper>();
            var mockIngMapper = new Mock<IngredientMapper>();
            var options = Utils.GetOptions(nameof(DeleteCocktail_Should));
            Utils.GetInMemoryTwoCocktails(options);

            //Act & Assert
            using (var assertContex = new CocktailMagicianContext(options))
            {
                var sut = new CocktailService(mockDateTimeprovider.Object, mockMapper.Object,
                    mockIngMapper.Object, assertContex);
                var result = await sut.DeleteCocktailAsync(2);

                Assert.IsTrue(result);
            }
        }
    }
}
