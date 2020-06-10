using CocktailMagician.Data;
using CocktailMagician.Models;
using CocktailMagician.Services;
using CocktailMagician.Services.Contracts;
using CocktailMagician.Services.DTOs;
using CocktailMagician.Services.Mappers;
using CocktailMagician.Services.Mappers.Contracts;
using CocktailMagician.Services.Providers.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.ServiceTests.CocktailServiceTests
{
    [TestClass]
    public class CreateCocktailAsync_Should
    {
        [TestMethod]
        public async Task CreateCocktail_WhenParamsAreValid()
        {
            //Arrange
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockMapper = new Mock<ICocktailMapper>();
            var mockIngMapper = new Mock<IngredientMapper>();
            var mockBarMapper = new Mock<IBarMapper>();
            var mockCocktailReviewService = new Mock<ICocktailReviewService>();
            var options = Utils.GetOptions(nameof(CreateCocktail_WhenParamsAreValid));
            var expected = new CocktailDTO
            {
                Name = "New Cocktail",
                Ingredients = new List<IngredientDTO>
                {
                    new IngredientDTO
                    {
                        Id = 1
                    },
                    new IngredientDTO
                    {
                        Id = 4
                    }
                }
            };
            Utils.GetInMemoryDataBase(options);
            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new CocktailService(mockDateTimeProvider.Object, mockMapper.Object,
                    mockIngMapper.Object, mockBarMapper.Object, assertContext, mockCocktailReviewService.Object);
                var result = await sut.CreateCocktailAsync(expected);

                Assert.IsInstanceOfType(result, typeof(CocktailDTO));
            }
        }
        [TestMethod]
        public async Task Throw_WhenNameIsEmpty()
        {
            //Arrange
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockMapper = new Mock<ICocktailMapper>();
            var mockIngMapper = new Mock<IngredientMapper>();
            var mockBarMapper = new Mock<IBarMapper>();
            var mockCocktailReviewService = new Mock<ICocktailReviewService>();
            var options = Utils.GetOptions(nameof(Throw_WhenNameIsEmpty));
            var cocktailDTO = new CocktailDTO { Name = string.Empty };
           
            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new CocktailService(mockDateTimeProvider.Object, mockMapper.Object,
                    mockIngMapper.Object, mockBarMapper.Object, assertContext, mockCocktailReviewService.Object);

                await Assert.ThrowsExceptionAsync<ArgumentException>(() => sut.CreateCocktailAsync(cocktailDTO));
            }
        }
        [TestMethod]
        public async Task Throw_WhenNameContainsNoLetter()
        {
            //Arrange
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockMapper = new Mock<ICocktailMapper>();
            var mockIngMapper = new Mock<IngredientMapper>();
            var mockBarMapper = new Mock<IBarMapper>();
            var mockCocktailReviewService = new Mock<ICocktailReviewService>();
            var options = Utils.GetOptions(nameof(Throw_WhenNameIsEmpty));
            var cocktailDTO = new CocktailDTO { Name = "Cosmo><Politen" };

            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new CocktailService(mockDateTimeProvider.Object, mockMapper.Object,
                    mockIngMapper.Object, mockBarMapper.Object, assertContext, mockCocktailReviewService.Object);

                await Assert.ThrowsExceptionAsync<ArgumentException>(() => sut.CreateCocktailAsync(cocktailDTO));
            }
        }
    }
}
