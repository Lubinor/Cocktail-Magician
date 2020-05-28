using CocktailMagician.Models;
using CocktailMagician.Services.DTOs;
using CocktailMagician.Services.Mappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CocktailMagician.Tests.ServiceTests.DTOMappersTests
{
    [TestClass]
    public class CityMapper_Should
    {
        [TestMethod]
        public void CorrectReturnInstanceType_ToCityDTO()
        {
            //Arrange
            var sut = new CityMapper();

            var options = Utils.GetOptions(nameof(CorrectReturnInstanceType_ToCityDTO));
            var city = Utils.ReturnOneCity(options);

            //Act
            var result = sut.MapToCityDTO(city);

            //Assert
            Assert.IsInstanceOfType(result, typeof(CityDTO));
        }

        [TestMethod]
        public void CorrectMapping_ToCityDTO()
        {
            //Arrange
            var sut = new CityMapper();

            var options = Utils.GetOptions(nameof(CorrectMapping_ToCityDTO));
            var city = Utils.ReturnOneCity(options);

            //Act
            var result = sut.MapToCityDTO(city);

            //Assert
            Assert.AreEqual(city.Id, result.Id);
            Assert.AreEqual(city.Name, result.Name);
        }

        [TestMethod]
        public void CorrectReturnInstanceType_ToCity()
        {
            //Arrange
            var sut = new CityMapper();

            var options = Utils.GetOptions(nameof(CorrectReturnInstanceType_ToCity));
            var cityDTO = Utils.ReturnOneCityDTO(options);

            //Act
            var result = sut.MapToCity(cityDTO);

            //Assert
            Assert.IsInstanceOfType(result, typeof(City));
        }

        [TestMethod]
        public void CorrectMapping_ToCity()
        {
            //Arrange
            var sut = new CityMapper();

            var options = Utils.GetOptions(nameof(CorrectMapping_ToCity));
            var cityDTO = Utils.ReturnOneCityDTO(options);

            //Act
            var result = sut.MapToCity(cityDTO);

            //Assert
            Assert.AreEqual(cityDTO.Name, result.Name);
        }
    }
}
