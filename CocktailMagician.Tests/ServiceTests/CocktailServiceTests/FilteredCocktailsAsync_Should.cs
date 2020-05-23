using CocktailMagician.Services.DTOs;
using CocktailMagician.Services.Mappers;
using CocktailMagician.Services.Providers.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.ServiceTests.CocktailServiceTests
{
    [TestClass]
    public class FilteredCocktailsAsync_Should
    {
        [TestMethod]
        public async Task FilterCocktailsByCocktailName()
        {
            //Arrange
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockCocktailMapper = new Mock<CocktailMapper>();
            var mockIngMapper = new Mock<IngredientMapper>();
            var options = Utils.GetOptions(nameof(FilterCocktailsByCocktailName));
            var filter = "bloody";
            var expected = new List<CocktailDTO>
            {
                new CocktailDTO
                {
                    Name = "Boody Mary"
                }
            };
            Utils.GetInMemoryTwoCocktails(options);

            //Act & Assert
            //using (var assertContext = new CocktailMagicianContext(options))
            //{
            //    var sut = new CocktailService(mockDateTimeProvider.Object, mockCocktailMapper.Object,
            //        mockIngMapper.Object, assertContext);
            //    var result = await sut.FilteredCocktailsAsync(filter);


            //}
        }
    }
}
