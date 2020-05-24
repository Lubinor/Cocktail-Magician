using CocktailMagician.Models;
using CocktailMagician.Services.DTOs;
using CocktailMagician.Services.Mappers;
using CocktailMagician.Services.Mappers.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CocktailMagician.Tests.ServiceTests.DTOMappersTests
{
    [TestClass]
    public class BarMapper_Should
    {
        [TestMethod]
        public void CorrectReturnInstanceType_ToBarDTO()
        {
            //Arrange
            var mockICocktailMapper = new Mock<ICocktailMapper>();

            var sut = new BarMapper(mockICocktailMapper.Object);

            var options = Utils.GetOptions(nameof(CorrectReturnInstanceType_ToBarDTO));
            var bar = Utils.ReturnOneBar(options);

            //Act
            var result = sut.MapToBarDTO(bar);

            //Assert
            Assert.IsInstanceOfType(result, typeof(BarDTO));
        }

        [TestMethod]
        public void CorrectMapping_ToBarDTO()
        {
            //Arrange
            var mockICocktailMapper = new Mock<ICocktailMapper>();

            var sut = new BarMapper(mockICocktailMapper.Object);

            var options = Utils.GetOptions(nameof(CorrectMapping_ToBarDTO));
            var bar = Utils.ReturnOneBar(options);

            //Act
            var result = sut.MapToBarDTO(bar);

            //Assert
            Assert.AreEqual(bar.Name, result.Name);
            Assert.AreEqual(bar.Address, result.Address);
            Assert.AreEqual(bar.CityId, result.CityId);
            Assert.AreEqual(bar.City.Name, result.CityName);
            Assert.AreEqual(bar.Phone, result.Phone);
            Assert.AreEqual(bar.AverageRating, result.AverageRating);
            Assert.AreEqual(bar.BarCocktails.Count, result.Cocktails.Count);
        }

        [TestMethod]
        public void CorrectReturnInstanceType_ToBar()
        {
            //Arrange
            var mockICocktailMapper = new Mock<ICocktailMapper>();

            var sut = new BarMapper(mockICocktailMapper.Object);

            var options = Utils.GetOptions(nameof(CorrectReturnInstanceType_ToBar));
            var barDTO = Utils.ReturnOneBarDTO(options);

            //Act
            var result = sut.MapToBar(barDTO);

            //Assert
            Assert.IsInstanceOfType(result, typeof(Bar));
        }

        [TestMethod]
        public void CorrectMapping_ToBar()
        {
            //Arrange
            var mockICocktailMapper = new Mock<ICocktailMapper>();

            //mockICocktailMapper
            //    .Setup(x => x.MapToCocktailDTO(It.IsAny<Cocktail>()))
            //    .Returns(new CocktailDTO { Id = 1, Name = "Bloody Mary" });

            var sut = new BarMapper(mockICocktailMapper.Object);

            var options = Utils.GetOptions(nameof(CorrectMapping_ToBar));
            var barDTO = Utils.ReturnOneBarDTO(options);

            //Act
            var result = sut.MapToBar(barDTO);

            //Assert
            Assert.AreEqual(barDTO.Name, result.Name);
            Assert.AreEqual(barDTO.CityId, result.CityId);
            Assert.AreEqual(barDTO.AverageRating, result.AverageRating);
            Assert.AreEqual(barDTO.Address, result.Address);
            Assert.AreEqual(barDTO.Phone, result.Phone);
            //Assert.AreEqual(barDTO.Cocktails.Count, result.BarCocktails.Count);
        }
    }
}
