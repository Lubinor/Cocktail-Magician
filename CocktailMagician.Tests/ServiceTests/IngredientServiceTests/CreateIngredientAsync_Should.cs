using CocktailMagician.Data;
using CocktailMagician.Services;
using CocktailMagician.Services.DTOs;
using CocktailMagician.Services.Mappers;
using CocktailMagician.Services.Providers.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.ServiceTests.IngredientServiceTests
{
    [TestClass]
    public class CreateIngredientAsync_Should
    {
        [TestMethod]
        public async Task CreateIngredient_WhenParamsAreValid()
        {
            //Arrange
            var mockDatetimeProvider = new Mock<IDateTimeProvider>();
            var mockMapper = new Mock<IngredientMapper>();
            var mockCocktailMapper = new Mock<CocktailMapper>();
            var options = Utils.GetOptions(nameof(CreateIngredient_WhenParamsAreValid));
            var ingredientDTO = new IngredientDTO
            {
                Name = "Black Pepper",
            };
            Utils.GetInMemoryThreeIngredients(options);

            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new IngredientService(mockDatetimeProvider.Object, mockMapper.Object,
                    mockCocktailMapper.Object, assertContext);
                var result = await sut.CreateIngredientAsync(ingredientDTO);

                Assert.IsInstanceOfType(result, typeof(IngredientDTO));
            }
        }
        [TestMethod]
        public async Task ReturnNull_WhenParamsAreInvalid()
        {
            //Arrange
            var mockDatetimeProvider = new Mock<IDateTimeProvider>();
            var mockMapper = new Mock<IngredientMapper>();
            var mockCocktailMapper = new Mock<CocktailMapper>();
            var options = Utils.GetOptions(nameof(ReturnNull_WhenParamsAreInvalid));
            var ingredientDTO = new IngredientDTO { Name = string.Empty};

            Utils.GetInMemoryThreeIngredients(options);

            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new IngredientService(mockDatetimeProvider.Object, mockMapper.Object,
                    mockCocktailMapper.Object, assertContext);
                var result = await sut.CreateIngredientAsync(ingredientDTO);

                Assert.IsNull(result);
            }
        }
    }
}
