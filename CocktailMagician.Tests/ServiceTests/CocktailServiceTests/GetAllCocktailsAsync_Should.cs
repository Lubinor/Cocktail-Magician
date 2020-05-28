using CocktailMagician.Data;
using CocktailMagician.Models;
using CocktailMagician.Services;
using CocktailMagician.Services.DTOs;
using CocktailMagician.Services.Mappers;
using CocktailMagician.Services.Mappers.Contracts;
using CocktailMagician.Services.Providers.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.ServiceTests.CocktailServiceTests
{
    [TestClass]
    public class GetAllCocktailsAsync_Should
    {
        [TestMethod]
        public async Task ReturnCorrectCocktails()
        {
            //Arrange
            var mockDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockCocktailMapper = new Mock<ICocktailMapper>();
            mockCocktailMapper.Setup(c => c.MapToCocktailDTO(It.IsAny<Cocktail>()))
                .Returns<Cocktail>(c => new CocktailDTO { Id = c.Id, Name = c.Name, AverageRating = c.AverageRating });
            var mockIngMapper = new Mock<IIngredientMapper>();
            //mockIngMapper.Setup(i => i.MapToIngredientDTO(It.IsAny<Ingredient>()))
            //    .Returns<Ingredient>(i => new IngredientDTO { Name = i.Name });
            var options = Utils.GetOptions(nameof(ReturnCorrectCocktails));
            var expected = new List<CocktailDTO>
            {
                new CocktailDTO
                {
                    Id = 1,
                    Name = "Bloody Mary",
                    AverageRating = 5.5,
                    //Ingredients = new List<IngredientDTO>
                    //{
                    //    new IngredientDTO
                    //    {
                    //        //Id = 1,
                    //        Name = "Vodka"
                    //    },
                    //    new IngredientDTO
                    //    {
                    //        //Id = 2,
                    //        Name = "Tomato Juice"
                    //    }
                    //},
                    //Bars = new List<BarDTO>
                    //{
                    //    new BarDTO
                    //    {
                    //        //Id = 1,
                    //        Name = "The Bar"
                    //    }
                    //}
                },
                new CocktailDTO
                {
                    Id = 2,
                    Name = "Gin Fizz",
                    AverageRating = 6.5,
                    //Ingredients = new List<IngredientDTO>
                    //{
                    //    new IngredientDTO
                    //    {
                    //        //Id = 3,
                    //        Name = "Dry Gin"
                    //    },
                    //    new IngredientDTO
                    //    {
                    //        //Id = 4,
                    //        Name = "Tonic"
                    //    }
                    //},
                    //Bars = new List<BarDTO>
                    //{
                    //    new BarDTO
                    //    {
                    //        //Id = 1,
                    //        Name = "The Bar"
                    //    }
                    //}
                }
            };
            Utils.GetInMemoryTwoCocktails(options);
            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new CocktailService(mockDateTimeProvider.Object, mockCocktailMapper.Object,
                    mockIngMapper.Object, assertContext);
                var result = (await sut.GetAllCocktailssAsync()).ToList();
                Assert.AreEqual(expected.Count, result.Count);
                for (int i = 0; i < expected.Count; i++)
                {
                    Assert.AreEqual(expected[i].Id, result[i].Id);
                    Assert.AreEqual(expected[i].Name, result[i].Name);
                    Assert.AreEqual(expected[i].AverageRating, result[i].AverageRating);
                }
            }
        }
    }
}
