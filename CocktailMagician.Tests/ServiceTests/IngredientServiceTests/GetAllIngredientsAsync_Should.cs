using CocktailMagician.Data;
using CocktailMagician.Models;
using CocktailMagician.Services;
using CocktailMagician.Services.DTOs;
using CocktailMagician.Services.Mappers.Contracts;
using CocktailMagician.Services.Providers.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.ServiceTests.IngredientServiceTests
{
    [TestClass]
    public class GetAllIngredients_Should
    {
        [TestMethod]
        public async Task ReturnCorrectIngredientsAsync()
        {
            //Arrange
            var mockDatetimeProvider = new Mock<IDateTimeProvider>();
            var mockMapper = new Mock<IIngredientMapper>();
            mockMapper.Setup(i => i.MapToIngredientDTO(It.IsAny<Ingredient>()))
                .Returns<Ingredient>(i => new IngredientDTO { Id = i.Id, Name = i.Name });
            var mockCocktailMapper = new Mock<ICocktailMapper>();
            var options = Utils.GetOptions(nameof(ReturnCorrectIngredientsAsync));
            var expected = new List<IngredientDTO>
            {
                new IngredientDTO
                {
                    Id = 1,
                    Name = "Vodka"
                    
                },
                new IngredientDTO
                {
                    Id = 2,
                    Name = "Tomato Juice"
                },
                new IngredientDTO
                {
                    Id = 3,
                    Name = "Tabasco"
                }
            };
            Utils.GetInMemoryThreeIngredients(options);

            // Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new IngredientService(mockDatetimeProvider.Object,mockMapper.Object,
                    mockCocktailMapper.Object, assertContext);
                var result = (await sut.GetAllIngredientsAsync()).ToList();
                Assert.AreEqual(expected.Count, result.Count);
                for (int i = 0; i < expected.Count; i++)
                {
                    Assert.AreEqual(expected[i].Id, result[i].Id);
                    Assert.AreEqual(expected[i].Name, result[i].Name);
                }
            }
        }
    }
}
