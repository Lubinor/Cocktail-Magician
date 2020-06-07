using CocktailMagician.Data;
using CocktailMagician.Services;
using CocktailMagician.Services.Mappers.Contracts;
using CocktailMagician.Services.Providers.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CocktailMagician.Tests.ServiceTests.IngredientServiceTests
{
    [TestClass]
    public class GetAllIngredientsCount_Should
    {
        [TestMethod]
        public void ReturnCorrectCountOfIngredients()
        {
            //Arrange
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockIngMapper = new Mock<IIngredientMapper>();
            var mockCocktailMapper = new Mock<ICocktailMapper>();
            var options = Utils.GetOptions(nameof(ReturnCorrectCountOfIngredients));
            Utils.GetInMemoryThreeIngredients(options);

            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new IngredientService(mockDateTimeProvider.Object, mockIngMapper.Object, 
                    mockCocktailMapper.Object, assertContext);
                var result = sut.GetAllIngredientsCount();

                Assert.AreEqual(3, result);
            }
        }
    }
}
