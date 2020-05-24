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
    public class CreateCityAsync_Should
    {
        [TestMethod]
        public async Task Return_WhenInputIsNull()
        {
            //Arrange
            var mockIDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockICityMapper = new Mock<ICityMapper>();
            var mockIBarMapper = new Mock<IBarMapper>();

            var options = Utils.GetOptions(nameof(Return_WhenInputIsNull));

            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new CityService(mockIDateTimeProvider.Object, assertContext, mockICityMapper.Object, mockIBarMapper.Object);

                var result = await sut.CreateCityAsync(null);

                Assert.IsNull(result);
            }
        }

        [TestMethod]
        public async Task Return_ParamsAreValid()
        {
            //Arrange
            var mockIDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockICityMapper = new Mock<ICityMapper>();
            var mockIBarMapper = new Mock<IBarMapper>();

            var options = Utils.GetOptions(nameof(Return_ParamsAreValid));

            var cityDTO = new CityDTO
                {
                    Id = 1,
                    Name = "Sofia",
                    Bars = new List<BarDTO>
                    {
                        new BarDTO
                        {
                            Id = 1,
                            Name = "Lorka",
                            CityId = 1,
                        }
                    }
                };

            mockICityMapper
            .Setup(x => x.MapToCityDTO(It.IsAny<City>()))
            .Returns<City>(c => new CityDTO { Id = c.Id, Name = c.Name });

            var city = Utils.ReturnOneCity(options);

            mockICityMapper
                .Setup(x => x.MapToCity(It.IsAny<CityDTO>()))
                .Returns<CityDTO>(c => new City { Id = c.Id, Name = c.Name });

            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new CityService(mockIDateTimeProvider.Object, assertContext, mockICityMapper.Object, mockIBarMapper.Object);

                var result = await sut.CreateCityAsync(cityDTO);

                Assert.AreEqual("Sofia", result.Name);
            }
        }
    }
}
