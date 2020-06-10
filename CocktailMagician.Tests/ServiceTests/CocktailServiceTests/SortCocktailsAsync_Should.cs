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
    public class SortCocktailsAsync_Should
    {
        [TestMethod]
        public async Task ReturnCocktailsSortedByNameAscending()
        {
            //Arrange
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockCocktailMapper = new Mock<ICocktailMapper>();
            mockCocktailMapper.Setup(c => c.MapToCocktailDTO(It.IsAny<Cocktail>()))
                .Returns<Cocktail>(c => new CocktailDTO { Name = c.Name });
            var mockIngMapper = new Mock<IIngredientMapper>();
            var mockBarMapper = new Mock<IBarMapper>();
            var mockCocktailReviewService = new Mock<ICocktailReviewService>();
            var options = Utils.GetOptions(nameof(ReturnCocktailsSortedByNameAscending));
            var sort = "name";
            var direction = "desc";
            var expected = new List<CocktailDTO>
            {
                new CocktailDTO
                {
                    Name = "Mojito"
                },
                new CocktailDTO
                {
                    Name = "Gin Fizz"
                },
                new CocktailDTO
                {
                    Name = "Bozdugan"
                }
            };
            Utils.GetInMemoryDataBase(options);
            
            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new CocktailService(mockDateTimeProvider.Object, mockCocktailMapper.Object,
                    mockIngMapper.Object,mockBarMapper.Object, assertContext, mockCocktailReviewService.Object);
                var result = await sut.ListAllCocktailsAsync(0,10,null,sort, direction);

                Assert.AreEqual(expected.Count, result.Count);
                for (int i = 0; i < expected.Count; i++)
                {
                    Assert.AreEqual(expected[i].Name, result[i].Name);
                }
            }
        }
        [TestMethod]
        public async Task ReturnCocktailsSortedByNameDescending()
        {
            //Arrange
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockCocktailMapper = new Mock<ICocktailMapper>();
            mockCocktailMapper.Setup(c => c.MapToCocktailDTO(It.IsAny<Cocktail>()))
                .Returns<Cocktail>(c => new CocktailDTO { Name = c.Name });
            var mockIngMapper = new Mock<IIngredientMapper>();
            var mockBarMapper = new Mock<IBarMapper>();
            var mockCocktailReviewService = new Mock<ICocktailReviewService>();
            var options = Utils.GetOptions(nameof(ReturnCocktailsSortedByNameDescending));
            var orderBy = "name";
            var direction = "asc";
            var expected = new List<CocktailDTO>
            {
                new CocktailDTO
                {
                    Name = "Bozdugan"
                },
                new CocktailDTO
                {
                    Name = "Gin Fizz"
                },
                new CocktailDTO
                {
                    Name = "Mojito"
                }
            };
            Utils.GetInMemoryDataBase(options);

            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new CocktailService(mockDateTimeProvider.Object, mockCocktailMapper.Object,
                    mockIngMapper.Object, mockBarMapper.Object, assertContext, mockCocktailReviewService.Object);
                var result = await sut.ListAllCocktailsAsync(0,10,null,orderBy,direction);

                Assert.AreEqual(expected.Count, result.Count);
                for (int i = 0; i < expected.Count; i++)
                {
                    Assert.AreEqual(expected[i].Name, result[i].Name);
                }
            }
        }
    }
}
