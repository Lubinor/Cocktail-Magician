using CocktailMagician.Data;
using CocktailMagician.Models;
using CocktailMagician.Services;
using CocktailMagician.Services.Contracts;
using CocktailMagician.Services.DTOs;
using CocktailMagician.Services.Mappers.Contracts;
using CocktailMagician.Services.Providers.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.ServiceTests.BarServiceTests
{
    [TestClass]
    public class GetAllBarsAsync_Should
    {
        [TestMethod]
        public async Task Return_IfNoBars()
        {
            //Arrange
            var mockIDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockIBarReviewService = new Mock<IBarReviewService>();

            var mockIBarMapper = new Mock<IBarMapper>();

            var options = Utils.GetOptions(nameof(Return_IfNoBars));

            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new BarService(mockIDateTimeProvider.Object, assertContext, mockIBarMapper.Object, mockIBarReviewService.Object);

                var result = await sut.GetAllBarsAsync();

                Assert.AreEqual(0, result.Count);
            }
        }

        [TestMethod]
        public async Task Return_ProperBarCount()
        {
            //Arrange
            var mockIDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockIBarReviewService = new Mock<IBarReviewService>();

            var mockIBarMapper = new Mock<IBarMapper>();

            var options = Utils.GetOptions(nameof(Return_ProperBarCount));
            var bars = Utils.ReturnTwoBars(options);

            using (var arrangeContext = new CocktailMagicianContext(options))
            {
                arrangeContext.Bars.AddRange(bars);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new BarService(mockIDateTimeProvider.Object, assertContext, mockIBarMapper.Object, mockIBarReviewService.Object);

                var result = await sut.GetAllBarsAsync();
                int barsCount = assertContext.Bars.Count();

                Assert.AreEqual(barsCount, result.Count);
            }
        }

        [TestMethod]
        public async Task Return_DefaultSortingById()
        {
            //Arrange
            var mockIDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockIBarReviewService = new Mock<IBarReviewService>();

            var mockIBarMapper = new Mock<IBarMapper>();
            mockIBarMapper
                .Setup(x => x.MapToBarDTO(It.IsAny<Bar>()))
                .Returns<Bar>(b => new BarDTO { Id = b.Id, Name = b.Name });

            var options = Utils.GetOptions(nameof(Return_DefaultSortingById));

            var bars = Utils.ReturnTwoBars(options);

            using (var arrangeContext = new CocktailMagicianContext(options))
            {
                arrangeContext.Bars.AddRange(bars);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new BarService(mockIDateTimeProvider.Object, assertContext, mockIBarMapper.Object, mockIBarReviewService.Object);

                var result = await sut.GetAllBarsAsync();
                var resultList = result.ToList();

                Assert.AreEqual(1, resultList[0].Id); //Id 1 -> Lorka
                Assert.AreEqual(2, resultList[1].Id); //Id 2 -> Bilkova
            }
        }

        [TestMethod]
        public async Task Return_CitiesNameAsc()
        {
            //Arrange
            var mockIDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockIBarReviewService = new Mock<IBarReviewService>();

            var mockIBarMapper = new Mock<IBarMapper>();
            mockIBarMapper
                .Setup(x => x.MapToBarDTO(It.IsAny<Bar>()))
                .Returns<Bar>(b => new BarDTO { Id = b.Id, Name = b.Name });

            var options = Utils.GetOptions(nameof(Return_CitiesNameAsc));

            var bars = Utils.ReturnTwoBars(options);

            using (var arrangeContext = new CocktailMagicianContext(options))
            {
                arrangeContext.Bars.AddRange(bars);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new BarService(mockIDateTimeProvider.Object, assertContext, mockIBarMapper.Object, mockIBarReviewService.Object);

                var result = await sut.GetAllBarsAsync("name");
                var resultList = result.ToList();

                Assert.AreEqual(2, resultList[0].Id); //Id 2 -> Bilkova
                Assert.AreEqual(1, resultList[1].Id); //Id 1 -> Lorka
            }
        }

        [TestMethod]
        public async Task Return_CitiesNameDesc()
        {
            //Arrange
            var mockIDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockIBarReviewService = new Mock<IBarReviewService>();

            var mockIBarMapper = new Mock<IBarMapper>();
            mockIBarMapper
                .Setup(x => x.MapToBarDTO(It.IsAny<Bar>()))
                .Returns<Bar>(b => new BarDTO { Id = b.Id, Name = b.Name });

            var options = Utils.GetOptions(nameof(Return_CitiesNameDesc));

            var bars = Utils.ReturnTwoBars(options);

            using (var arrangeContext = new CocktailMagicianContext(options))
            {
                arrangeContext.Bars.AddRange(bars);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new BarService(mockIDateTimeProvider.Object, assertContext, mockIBarMapper.Object, mockIBarReviewService.Object);

                var result = await sut.GetAllBarsAsync("name_desc");
                var resultList = result.ToList();

                Assert.AreEqual(1, resultList[0].Id); //Id 1 -> Lorka
                Assert.AreEqual(2, resultList[1].Id); //Id 2 -> Bilkova
            }
        }
    }
}
