using CocktailMagician.Data;
using CocktailMagician.Models;
using CocktailMagician.Services;
using CocktailMagician.Services.DTOs;
using CocktailMagician.Services.Mappers.Contracts;
using CocktailMagician.Services.Providers.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
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
                var sut = new CityService(mockIDateTimeProvider.Object, assertContext, mockICityMapper.Object);

                var result = await sut.GetCityAsync(2);

                Assert.IsNull(result);
            }
        }

        [TestMethod]
        public async Task Return_WhenParamsAreValid()
        {
            //Arrange
            var mockIDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockICityMapper = new Mock<ICityMapper>();
            mockICityMapper
                .Setup(x => x.MapToCityDTO(It.IsAny<City>()))
                .Returns(new CityDTO
                {
                    Id = 1,
                    Name = "Sofia",
                    Bars = new List<BarDTO>
                    {
                        new BarDTO
                        {
                        Id = 1,
                        Name = "Lorka",
                        CityId = 1
                        }
                    }
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
                var sut = new CityService(mockIDateTimeProvider.Object, assertContext, mockICityMapper.Object);

                var result = await sut.GetCityAsync(1);

                Assert.AreEqual(city.Id, result.Id);
                Assert.AreEqual(city.Name, result.Name);
                Assert.AreEqual(city.Bars.Count, result.Bars.Count);
                //collection?
            }
        }
    }
}
