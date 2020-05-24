using CocktailMagician.Data;
using CocktailMagician.Models;
using CocktailMagician.Services;
using CocktailMagician.Services.DTOs;
using CocktailMagician.Services.Mappers.Contracts;
using CocktailMagician.Services.Providers.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.ServiceTests.CityServiceTests
{
    [TestClass]
    public class GetCityAsync_Should
    {
        [TestMethod]
        public async Task ReturnNull_CityDoesNotExist()
        {
            //Arrange
            var mockIDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockICityMapper = new Mock<ICityMapper>();
            var mockIBarMapper = new Mock<IBarMapper>();

            var options = Utils.GetOptions(nameof(ReturnNull_CityDoesNotExist));

            var city = Utils.ReturnOneCity(options);

            using (var arrangeContext = new CocktailMagicianContext(options))
            {
                arrangeContext.Cities.Add(city);
                await arrangeContext.SaveChangesAsync();
            }
            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new CityService(mockIDateTimeProvider.Object, assertContext, mockICityMapper.Object, mockIBarMapper.Object);

                var result = await sut.GetCityAsync(2);

                Assert.IsNull(result);
            }
        }

        [TestMethod]
        public async Task Return_WhenParamsAreValid()
        {
            //Arrange
            var mockIDateTimeProvider = new Mock<IDateTimeProvider>();

            var mockIBarMapper = new Mock<IBarMapper>();
            mockIBarMapper
                .Setup(x => x.MapToBarDTO(It.IsAny<Bar>()))
                .Returns<Bar>(b => new BarDTO
                {
                    Id = b.Id,
                    Phone = b.Phone,
                    Name = b.Name,
                    Address = b.Address,
                    AverageRating = b.AverageRating,
                });

            var mockICityMapper = new Mock<ICityMapper>();
            mockICityMapper
                .Setup(x => x.MapToCityDTO(It.IsAny<City>()))
                .Returns<City>(c => new CityDTO
                {
                    Id = c.Id,
                    Name = c.Name
                });

            var options = Utils.GetOptions(nameof(Return_WhenParamsAreValid));

            var city = Utils.ReturnOneCity(options);

            using (var arrangeContext = new CocktailMagicianContext(options))
            {
                arrangeContext.Cities.Add(city);
                await arrangeContext.SaveChangesAsync();
            }
            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new CityService(mockIDateTimeProvider.Object, assertContext, mockICityMapper.Object, mockIBarMapper.Object);

                var result = await sut.GetCityAsync(1);

                Assert.AreEqual(city.Id, result.Id);
                Assert.AreEqual(city.Name, result.Name);
                Assert.AreEqual(city.Bars.Count, result.Bars.Count);
            }
        }
    }
}
