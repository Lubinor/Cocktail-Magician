using CocktailMagician.Data;
using CocktailMagician.Models;
using CocktailMagician.Services;
using CocktailMagician.Services.Contracts;
using CocktailMagician.Services.DTOs;
using CocktailMagician.Services.Mappers.Contracts;
using CocktailMagician.Services.Providers.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.ServiceTests.CocktailServiceTests
{
    [TestClass]
    public class FilteredCocktailsAsync_Should
    {
        [TestMethod]
        public async Task FilterCocktailsByCocktailName()
        {
            //Arrange
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockCocktailMapper = new Mock<ICocktailMapper>();
            mockCocktailMapper
                .Setup(c=>c.MapToCocktailDTO(It.IsAny<Cocktail>()))
                .Returns<Cocktail>(c=> new CocktailDTO { Name = c.Name});
            var mockIngMapper = new Mock<IIngredientMapper>();
            var mockBarMapper = new Mock<IBarMapper>();
            var mockIReviewService = new Mock<ICocktailReviewService>();
            var options = Utils.GetOptions(nameof(FilterCocktailsByCocktailName));
            var filter = "mAry";
            var expected = new List<CityDTO>
            {
                new CityDTO
                {
                    Name = "Bloody Mary"
                }
            };
            Utils.GetInMemoryTwoCocktails(options);

            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new CocktailService(mockDateTimeProvider.Object, mockCocktailMapper.Object,
                    mockIngMapper.Object, mockBarMapper.Object, assertContext, mockIReviewService.Object);
                var result = await sut.FilteredCocktailsAsync(filter);

                Assert.AreEqual(expected.Count, result.Count);
                
                for (int i = 0; i < expected.Count; i++)
                {
                    Assert.AreEqual(expected[i].Name, result[i].Name);
                }
            }
        }
        [TestMethod]
        public async Task FilterCocktailsByIngredientName()
        {
            //Arrange
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockCocktailMapper = new Mock<ICocktailMapper>();
            mockCocktailMapper
                .Setup(c => c.MapToCocktailDTO(It.IsAny<Cocktail>()))
                .Returns<Cocktail>(c => new CocktailDTO { Name = c.Name });
            var mockIngMapper = new Mock<IIngredientMapper>();
            mockIngMapper
                .Setup(i => i.MapToIngredientDTO(It.IsAny<Ingredient>()))
                .Returns<Ingredient>(i => new IngredientDTO { Name = i.Name });
            var mockBarMapper = new Mock<IBarMapper>();
            var mockIReviewService = new Mock<ICocktailReviewService>();
            var options = Utils.GetOptions(nameof(FilterCocktailsByIngredientName));
            var filter = "toNic";
            var expected = new List<CityDTO>
            {
                new CityDTO
                {
                    Name = "Gin Fizz"
                }
            };
            Utils.GetInMemoryTwoCocktails(options);

            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new CocktailService(mockDateTimeProvider.Object, mockCocktailMapper.Object,
                    mockIngMapper.Object, mockBarMapper.Object, assertContext, mockIReviewService.Object);
                var result = await sut.FilteredCocktailsAsync(filter);

                Assert.AreEqual(expected.Count, result.Count);

                for (int i = 0; i < expected.Count; i++)
                {
                    Assert.AreEqual(expected[i].Name, result[i].Name);
                }
            }
        }
        [TestMethod]
        public async Task FilterCocktailsByRating()
        {
            //Arrange
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockCocktailMapper = new Mock<ICocktailMapper>();
            mockCocktailMapper
                .Setup(c => c.MapToCocktailDTO(It.IsAny<Cocktail>()))
                .Returns<Cocktail>(c => new CocktailDTO { Name = c.Name, AverageRating = c.AverageRating });
            var mockIngMapper = new Mock<IIngredientMapper>();
            mockIngMapper
                .Setup(i => i.MapToIngredientDTO(It.IsAny<Ingredient>()))
                .Returns<Ingredient>(i => new IngredientDTO { Name = i.Name });
            var mockBarMapper = new Mock<IBarMapper>();
            var mockIReviewService = new Mock<ICocktailReviewService>();
            var options = Utils.GetOptions(nameof(FilterCocktailsByRating));
            var expected = new List<CocktailDTO>
            {
                new CocktailDTO
                {
                    Name = "Bloody Mary",
                    AverageRating = 5.5
                },
                new CocktailDTO
                {
                    Name = "Gin Fizz",
                    AverageRating = 6.5
                }
            };
            Utils.GetInMemoryTwoCocktails(options);

            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new CocktailService(mockDateTimeProvider.Object, mockCocktailMapper.Object,
                    mockIngMapper.Object, mockBarMapper.Object, assertContext, mockIReviewService.Object);
                var result = await sut.FilteredCocktailsAsync("5");

                Assert.AreEqual(expected.Count, result.Count);

                for (int i = 0; i < expected.Count; i++)
                {
                    Assert.AreEqual(expected[i].Name, result[i].Name);
                }
            }
        }
    }
}
