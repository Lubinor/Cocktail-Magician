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
    public class GetBarAsync_Should
    {
        [TestMethod]
        public async Task ReturnNull_IfNoBar()
        {
            //Arrange
            var mockIDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockIBarMapper = new Mock<IBarMapper>();

            var options = Utils.GetOptions(nameof(ReturnNull_IfNoBar));

            var bars = Utils.ReturnTwoBars(options);

            using (var arrangeContext = new CocktailMagicianContext(options))
            {
                arrangeContext.Bars.AddRange(bars);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new BarService(mockIDateTimeProvider.Object, assertContext, mockIBarMapper.Object);

                var result = await sut.GetBarAsync(4);

                Assert.IsNull(result);
            }
        }

        [TestMethod]
        public async Task ReturnBar_IfParamsAreValid()
        {
            //Arrange
            var mockIDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockIBarMapper = new Mock<IBarMapper>();
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

            var options = Utils.GetOptions(nameof(ReturnBar_IfParamsAreValid));

            var bar = Utils.ReturnOneBar(options);

            using (var arrangeContext = new CocktailMagicianContext(options))
            {
                arrangeContext.Bars.Add(bar);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new BarService(mockIDateTimeProvider.Object, assertContext, mockIBarMapper.Object);

                var result = await sut.GetBarAsync(1);

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