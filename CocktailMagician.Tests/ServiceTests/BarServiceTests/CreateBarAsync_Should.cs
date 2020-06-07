using CocktailMagician.Data;
using CocktailMagician.Models;
using CocktailMagician.Services;
using CocktailMagician.Services.Contracts;
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
    public class CreateBarAsync_Should
    {
        [TestMethod]
        public async Task Return_WhenCreateBarInputIsNull()
        {
            //Arrange
            var mockIDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockIBarMapper = new Mock<IBarMapper>();
            var mockIBarReviewService = new Mock<IBarReviewService>();

            var options = Utils.GetOptions(nameof(Return_WhenCreateBarInputIsNull));

            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new BarService(mockIDateTimeProvider.Object, assertContext, mockIBarMapper.Object, mockIBarReviewService.Object);

                var result = await sut.CreateBarAsync(null);

                Assert.IsNull(result);
            }
        }

        [TestMethod]
        public async Task ReturnBar_WhenParamsAreValid()
        {
            //Arrange
            var mockIDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockIBarMapper = new Mock<IBarMapper>();
            var mockIBarReviewService = new Mock<IBarReviewService>();

            var options = Utils.GetOptions(nameof(ReturnBar_WhenParamsAreValid));

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


            var barDTO = Utils.ReturnOneBarDTO(options);

            mockIBarMapper
                .Setup(x => x.MapToBar(It.IsAny<BarDTO>()))
                .Returns<BarDTO>(b => new Bar
                {
                    Id = b.Id,
                    Name = b.Name,
                    CityId = b.CityId,
                    Address = b.Address,
                    Phone = b.Phone,
                    AverageRating = b.AverageRating
                });

            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new BarService(mockIDateTimeProvider.Object, assertContext, mockIBarMapper.Object, mockIBarReviewService.Object);

                var result = await sut.CreateBarAsync(barDTO);

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
