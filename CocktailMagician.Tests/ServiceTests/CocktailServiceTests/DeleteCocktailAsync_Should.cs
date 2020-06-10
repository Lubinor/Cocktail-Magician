using CocktailMagician.Data;
using CocktailMagician.Services;
using CocktailMagician.Services.Contracts;
using CocktailMagician.Services.Mappers;
using CocktailMagician.Services.Mappers.Contracts;
using CocktailMagician.Services.Providers.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
            var mockDateTimeprovider = new Mock<IDateTimeProvider>();
            var mockMapper = new Mock<CocktailMapper>();
            var mockIngMapper = new Mock<IngredientMapper>();
            var mockBarMapper = new Mock<IBarMapper>();
            var mockReviewService = new Mock<ICocktailReviewService>();
            var options = Utils.GetOptions(nameof(DeleteCocktail_Should));
            Utils.GetInMemoryTwoCocktails(options);

            //Act & Assert
            using (var assertContex = new CocktailMagicianContext(options))
            {
                var sut = new CocktailService(mockDateTimeprovider.Object, mockMapper.Object,
                    mockIngMapper.Object, mockBarMapper.Object, assertContex, mockReviewService.Object);
                var result = await sut.DeleteCocktailAsync(2);

                Assert.IsTrue(result);
            }
        }
    }
}
