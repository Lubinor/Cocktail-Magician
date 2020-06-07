using CocktailMagician.Data;
using CocktailMagician.Models;
using CocktailMagician.Services;
using CocktailMagician.Services.DTOs;
using CocktailMagician.Services.Mappers.Contracts;
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
            var mockMapper = new Mock<IIngredientMapper>();
            mockMapper.Setup(i => i.MapToIngredient(It.IsAny<IngredientDTO>()))
                .Returns<IngredientDTO>(i => new Ingredient { Name = i.Name });
            var mockCocktailMapper = new Mock<ICocktailMapper>();
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
            var mockMapper = new Mock<IIngredientMapper>();
            mockMapper.Setup(i => i.MapToIngredientDTO(It.IsAny<Ingredient>()))
                .Returns<Ingredient>(i => new IngredientDTO { Name = i.Name });
            var mockCocktailMapper = new Mock<ICocktailMapper>();
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
