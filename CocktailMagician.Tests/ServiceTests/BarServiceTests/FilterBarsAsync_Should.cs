using CocktailMagician.Data;
using CocktailMagician.Models;
using CocktailMagician.Services;
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
    public class FilterBarsAsync_Should
    {
        [TestMethod]
        public async Task ReturnNull_IfFilterIsNull()
        {
            //Arrange
            var mockIDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockIBarMapper = new Mock<IBarMapper>();
            mockIBarMapper
                .Setup(x => x.MapToBarDTO(It.IsAny<Bar>()))
                .Returns<Bar>(b => new BarDTO { Id = b.Id, Name = b.Name });

            var options = Utils.GetOptions(nameof(ReturnNull_IfFilterIsNull));

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

                var result = await sut.FilterBarsAsync(null);

                Assert.IsNull(result);
            }
        }

        [TestMethod]
        public async Task ReturnEmpty_IfNoMatchesFound()
        {
            //Arrange
            var mockIDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockIBarMapper = new Mock<IBarMapper>();
            mockIBarMapper
                .Setup(x => x.MapToBarDTO(It.IsAny<Bar>()))
                .Returns<Bar>(b => new BarDTO { Id = b.Id, Name = b.Name });

            var options = Utils.GetOptions(nameof(ReturnEmpty_IfNoMatchesFound));

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

                var result = await sut.FilterBarsAsync("Zzzz");

                Assert.AreEqual(0, result.Count);
            }
        }

        [TestMethod]
        public async Task ReturnValid_StringFilter()
        {
            //Arrange
            var mockIDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockIBarMapper = new Mock<IBarMapper>();
            mockIBarMapper
                .Setup(x => x.MapToBarDTO(It.IsAny<Bar>()))
                .Returns<Bar>(b => new BarDTO { Id = b.Id, Name = b.Name });

            var options = Utils.GetOptions(nameof(ReturnValid_StringFilter));

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

                var result = await sut.FilterBarsAsync("Lor");
                var expectedBar = result.FirstOrDefault(x => x.Name == "Lorka");

                Assert.AreEqual(1, result.Count);
                Assert.AreEqual("Lorka", expectedBar.Name);
            }
        }

        [TestMethod]
        public async Task ReturnValid_DoubleFilter()
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
                    AverageRating = b.AverageRating
                });

            var options = Utils.GetOptions(nameof(ReturnValid_DoubleFilter));

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

                var result = await sut.FilterBarsAsync("3.7");
                var expectedBar = result.FirstOrDefault(x => x.AverageRating >= 3.7);

                Assert.AreEqual(1, result.Count);
                Assert.AreEqual("Bilkova", expectedBar.Name);
            }
        }
    }
}