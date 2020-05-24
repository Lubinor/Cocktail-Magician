using CocktailMagician.Data;
using CocktailMagician.Models;
using CocktailMagician.Services;
using CocktailMagician.Services.DTOs;
using CocktailMagician.Services.Mappers.Contracts;
using CocktailMagician.Services.Providers.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.ServiceTests.BarServiceTests
{
    [TestClass]
    public class UpdateBarAsync_Should
    {
        [TestMethod]
        public async Task ReturnNull_IfBarDoesNotExist()
        {
            //Arrange
            var mockIDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockIBarMapper = new Mock<IBarMapper>();

            var options = Utils.GetOptions(nameof(ReturnNull_IfBarDoesNotExist));

            mockIBarMapper
                .Setup(x => x.MapToBarDTO(It.IsAny<Bar>()))
                .Returns<Bar>(b => new BarDTO
                {
                    Id = b.Id,
                    Name = b.Name,
                    CityId = b.CityId,
                    Address = b.Address,
                    Phone = b.Phone,
                    AverageRating = b.AverageRating
                });

            var bar = Utils.ReturnOneBar(options);

            var barDTO = new BarDTO
            {
                Name = "Summer Bar",
                CityId = 2,
                Address = "Sunny Beach 53",
                Phone = "0888 111 111",
            };

            using (var arrangeContext = new CocktailMagicianContext(options))
            {
                arrangeContext.Bars.Add(bar);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new BarService(mockIDateTimeProvider.Object, assertContext, mockIBarMapper.Object);

                var result = await sut.UpdateBarAsync(5, barDTO);

                Assert.IsNull(result);
            }
        }

        [TestMethod]
        public async Task ReturnUpdatedBarDTO_WhenParamsAreValid()
        {
            //Arrange
            var mockIDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockIBarMapper = new Mock<IBarMapper>();

            var options = Utils.GetOptions(nameof(ReturnUpdatedBarDTO_WhenParamsAreValid));

            mockIBarMapper
                .Setup(x => x.MapToBarDTO(It.IsAny<Bar>()))
                .Returns<Bar>(b => new BarDTO
                {
                    Id = b.Id,
                    Name = b.Name,
                    CityId = b.CityId,
                    Address = b.Address,
                    Phone = b.Phone,
                    AverageRating = b.AverageRating
                });

            var bar = Utils.ReturnOneBar(options);

            var barDTO = new BarDTO
            {
                Name = "Summer Bar",
                CityId = 2,
                Address = "Sunny Beach 53",
                Phone = "0888 111 111",
            };

            using (var arrangeContext = new CocktailMagicianContext(options))
            {
                arrangeContext.Bars.Add(bar);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new BarService(mockIDateTimeProvider.Object, assertContext, mockIBarMapper.Object);

                var result = await sut.UpdateBarAsync(1, barDTO);

                var expected = await assertContext.Bars.FirstOrDefaultAsync(b => b.Id == 1);

                Assert.AreEqual(expected.Id, result.Id);
                Assert.AreEqual(expected.Name, result.Name);
                Assert.AreEqual(expected.CityId, result.CityId);
                Assert.AreEqual(expected.Address, result.Address);
                Assert.AreEqual(expected.Phone, result.Phone);
                Assert.AreEqual(expected.AverageRating, result.AverageRating);
            }
        }
    }
}