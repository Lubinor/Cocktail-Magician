using CocktailMagician.Data;
using CocktailMagician.Models;
using CocktailMagician.Services;
using CocktailMagician.Services.DTOs;
using CocktailMagician.Services.Mappers.Contracts;
using CocktailMagician.Services.Providers.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.ServiceTests.CityServiceTests
{
    [TestClass]
    public class UpdateCityAsync_Should
    {
        [TestMethod]
        public async Task ReturnNull_IfCityDoesNotExist()
        {
            //Arrange
            var mockIDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockICityMapper = new Mock<ICityMapper>();
            var mockIBarMapper = new Mock<IBarMapper>();

            var options = Utils.GetOptions(nameof(ReturnNull_IfCityDoesNotExist));

            var city = Utils.ReturnOneCity(options);

            using (var arrangeContext = new CocktailMagicianContext(options))
            {
                arrangeContext.Cities.Add(city);
                await arrangeContext.SaveChangesAsync();
            }

            var updatedCityDTO = new CityDTO { Id = 1, Name = "Varna" };

            mockICityMapper
                .Setup(x => x.MapToCityDTO(It.IsAny<City>()))
                .Returns<City>(c => new CityDTO { Id = c.Id, Name = c.Name });

            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new CityService(mockIDateTimeProvider.Object, assertContext, mockICityMapper.Object, mockIBarMapper.Object);

                var result = await sut.UpdateCityAsync(4, updatedCityDTO);

                Assert.IsNull(result);
            }
        }

        [TestMethod]
        public async Task ReturnUpdatedCityDTO_WhenParamsAreValid()
        {
            //Arrange
            var mockIDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockICityMapper = new Mock<ICityMapper>();
            var mockIBarMapper = new Mock<IBarMapper>();

            var options = Utils.GetOptions(nameof(ReturnUpdatedCityDTO_WhenParamsAreValid));

            var city = Utils.ReturnOneCity(options);

            using (var arrangeContext = new CocktailMagicianContext(options))
            {
                arrangeContext.Cities.Add(city);
                await arrangeContext.SaveChangesAsync();
            }

            var updatedCityDTO = new CityDTO { Id = 1, Name = "Varna" };

            mockICityMapper
                .Setup(x => x.MapToCityDTO(It.IsAny<City>()))
                .Returns<City>(c => new CityDTO { Id = c.Id, Name = c.Name });

            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new CityService(mockIDateTimeProvider.Object, assertContext, mockICityMapper.Object, mockIBarMapper.Object);

                var result = await sut.UpdateCityAsync(1, updatedCityDTO);

                Assert.AreEqual(updatedCityDTO.Id, result.Id);
                Assert.AreEqual(updatedCityDTO.Name, result.Name);
            }
        }
    }
}
