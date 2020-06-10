using CocktailMagician.Data;
using CocktailMagician.Models;
using CocktailMagician.Services;
using CocktailMagician.Services.DTOs;
using CocktailMagician.Services.Mappers.Contracts;
using CocktailMagician.Services.Providers.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
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
            Utils.GetInMemoryDataBase(options);

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
        public async Task Throw_WhenParamsNameIsEmpty()
        {
            //Arrange
            var mockDatetimeProvider = new Mock<IDateTimeProvider>();
            var mockMapper = new Mock<IIngredientMapper>();
            mockMapper.Setup(i => i.MapToIngredientDTO(It.IsAny<Ingredient>()))
                .Returns<Ingredient>(i => new IngredientDTO { Name = i.Name });
            var mockCocktailMapper = new Mock<ICocktailMapper>();
            var options = Utils.GetOptions(nameof(Throw_WhenParamsNameIsEmpty));
            var ingredientDTO = new IngredientDTO { Name = string.Empty};

            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new IngredientService(mockDatetimeProvider.Object, mockMapper.Object,
                    mockCocktailMapper.Object, assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentException>(() => sut.CreateIngredientAsync(ingredientDTO));
            }
        }
        [TestMethod]
        public async Task Throw_WhenParamsNameContainsNotLetter()
        {
            //Arrange
            var mockDatetimeProvider = new Mock<IDateTimeProvider>();
            var mockMapper = new Mock<IIngredientMapper>();
            mockMapper.Setup(i => i.MapToIngredientDTO(It.IsAny<Ingredient>()))
                .Returns<Ingredient>(i => new IngredientDTO { Name = i.Name });
            var mockCocktailMapper = new Mock<ICocktailMapper>();
            var options = Utils.GetOptions(nameof(Throw_WhenParamsNameContainsNotLetter));
            var ingredientDTO = new IngredientDTO { Name = "@Vodka" };

            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new IngredientService(mockDatetimeProvider.Object, mockMapper.Object,
                    mockCocktailMapper.Object, assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentException>(() => sut.CreateIngredientAsync(ingredientDTO));
            }
        }
        [TestMethod]
        public async Task Throw_WhenNameTooShort()
        {
            //Arrange
            var mockDatetimeProvider = new Mock<IDateTimeProvider>();
            var mockMapper = new Mock<IIngredientMapper>();
            mockMapper.Setup(i => i.MapToIngredientDTO(It.IsAny<Ingredient>()))
                .Returns<Ingredient>(i => new IngredientDTO { Name = i.Name });
            var mockCocktailMapper = new Mock<ICocktailMapper>();
            var options = Utils.GetOptions(nameof(Throw_WhenNameTooShort));
            var ingredientDTO = new IngredientDTO { Name = "Vo" };

            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new IngredientService(mockDatetimeProvider.Object, mockMapper.Object,
                    mockCocktailMapper.Object, assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(() => sut.CreateIngredientAsync(ingredientDTO));
            }
        }
        [TestMethod]
        public async Task Throw_WhenNameTooLong()
        {
            //Arrange
            var mockDatetimeProvider = new Mock<IDateTimeProvider>();
            var mockMapper = new Mock<IIngredientMapper>();
            mockMapper.Setup(i => i.MapToIngredientDTO(It.IsAny<Ingredient>()))
                .Returns<Ingredient>(i => new IngredientDTO { Name = i.Name });
            var mockCocktailMapper = new Mock<ICocktailMapper>();
            var options = Utils.GetOptions(nameof(Throw_WhenNameTooLong));
            var ingredientDTO = new IngredientDTO { Name = new String('a',31) };

            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new IngredientService(mockDatetimeProvider.Object, mockMapper.Object,
                    mockCocktailMapper.Object, assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(() => sut.CreateIngredientAsync(ingredientDTO));
            }
        }
        [TestMethod]
        public async Task Throw_WhenNameAlreadyExist()
        {
            //Arrange
            var mockDatetimeProvider = new Mock<IDateTimeProvider>();
            var mockMapper = new Mock<IIngredientMapper>();
            mockMapper.Setup(i => i.MapToIngredientDTO(It.IsAny<Ingredient>()))
                .Returns<Ingredient>(i => new IngredientDTO { Name = i.Name });
            var mockCocktailMapper = new Mock<ICocktailMapper>();
            var options = Utils.GetOptions(nameof(Throw_WhenNameAlreadyExist));
            var ingredientDTO = new IngredientDTO { Name = "Rum" };

            Utils.GetInMemoryDataBase(options);

            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new IngredientService(mockDatetimeProvider.Object, mockMapper.Object,
                    mockCocktailMapper.Object, assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentException>(() => sut.CreateIngredientAsync(ingredientDTO));
            }
        }
        [TestMethod]
        public async Task Throw_WhenObjectIsNull()
        {
            //Arrange
            var mockDatetimeProvider = new Mock<IDateTimeProvider>();
            var mockMapper = new Mock<IIngredientMapper>();
            mockMapper.Setup(i => i.MapToIngredientDTO(It.IsAny<Ingredient>()))
                .Returns<Ingredient>(i => new IngredientDTO { Name = i.Name });
            var mockCocktailMapper = new Mock<ICocktailMapper>();
            var options = Utils.GetOptions(nameof(Throw_WhenObjectIsNull));

            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new IngredientService(mockDatetimeProvider.Object, mockMapper.Object,
                    mockCocktailMapper.Object, assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.CreateIngredientAsync(null));
            }
        }
    }
}
