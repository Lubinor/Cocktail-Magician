using CocktailMagician.Data;
using CocktailMagician.Services;
using CocktailMagician.Services.DTOs;
using CocktailMagician.Services.Mappers;
using CocktailMagician.Services.Provider.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.ServiceTests.CocktailServiceTests
{
    [TestClass]
    public class UpdateCocktail_Should
    {
        [TestMethod]
        public async Task UpdateCocktail_WhenParamsAreValid()
        {
            //Arrange
            var mockDateTimeprovider = new Mock<IDatetimeProvider>();
            var mockIngMapper = new Mock<IngredientMapper>();
            var mockCocktailMapper = new Mock<CocktailMapper>();
            var options = Utils.GetOptions(nameof(UpdateCocktail_WhenParamsAreValid));
            Utils.GetInMemoryTwoCocktails(options);
            var expected = new CocktailDTO
            {
                Id = 2,
                Name = "Gin sTonik",
                Ingredients = new List<IngredientDTO>
                {
                    new IngredientDTO
                    {
                        Name = "Dry Gin"
                    },
                    new IngredientDTO
                    {
                        Name = "Tonic"
                    }
                }
            }; var newDTO = new CocktailDTO
            {
                Id = 2,
                Name = "Gin sTonik",
                Ingredients = new List<IngredientDTO>
                {
                    new IngredientDTO
                    {
                        Name = "Dry Gin"
                    },
                    new IngredientDTO
                    {
                        Name = "Tonic"
                    }
                }
            };

            //Act & Assert

            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new CocktailService(mockDateTimeprovider.Object, mockCocktailMapper.Object,
                   mockIngMapper.Object, assertContext);
                var result = await sut.UpdateCocktailAsync(2, newDTO);

                Assert.AreEqual(expected.Id, result.Id);
                Assert.AreEqual(expected.Name, result.Name);
                Assert.AreEqual(expected.Ingredients.ToList().Count, result.Ingredients.ToList().Count);
                CollectionAssert.AreEqual(expected.Ingredients.ToList(), result.Ingredients.ToList());
            }
        }
    }
}
 