using CocktailMagician.Data;
using CocktailMagician.Models;
using CocktailMagician.Services;
using CocktailMagician.Services.Mappers.Contracts;
using CocktailMagician.Services.Providers.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.ServiceTests.CityServiceTests
{
    [TestClass]
    public class GetAllCitiesAsync_Should
    {
        [TestMethod]
        public async Task Return_IfNoCities()
        {
            //Arrange
            var mockIDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockICityMapper = new Mock<ICityMapper>();
            var mockIBarMapper = new Mock<IBarMapper>();

            var options = Utils.GetOptions(nameof(Return_IfNoCities));

            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new CityService(mockIDateTimeProvider.Object, assertContext, mockICityMapper.Object, mockIBarMapper.Object);

                var result = await sut.GetAllCitiesAsync();

                Assert.AreEqual(0, result.Count);
            }
        }

        [TestMethod]
        public async Task Return_ProperCityCount()
        {
            //Arrange
            var mockIDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockICityMapper = new Mock<ICityMapper>();

            var mockIBarMapper = new Mock<IBarMapper>();

            var options = Utils.GetOptions(nameof(Return_ProperCityCount));

            var city = Utils.ReturnOneCity(options);
            var city2 = new City { Id = 2, Name = "Varna" };

            using (var arrangeContext = new CocktailMagicianContext(options))
            {
                arrangeContext.Cities.Add(city);
                arrangeContext.Cities.Add(city2);
                await arrangeContext.SaveChangesAsync();
            }
            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new CityService(mockIDateTimeProvider.Object, assertContext, mockICityMapper.Object, mockIBarMapper.Object);

                var result = await sut.GetAllCitiesAsync();

                Assert.AreEqual(2, result.Count);
            }
        }
    }
}
