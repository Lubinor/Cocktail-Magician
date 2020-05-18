using CocktailMagician.Services.Mappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CocktailMagician.Tests.ServiceTests.DTOMappersTests
{
    [TestClass]
    public class CityMapper_Should
    {
        [TestMethod]
        public void CorrectMapping_ToDTO()
        {
            var sut = new CityMapper();

            var options = Utils.GetOptions(nameof(CorrectMapping_ToDTO));
            var city = Utils.ReturnOneCity(options);

            var result = sut.CityToCityDTO(city);

            Assert.AreEqual(city.Id, result.Id);
            Assert.AreEqual(city.Name, result.Name);
            Assert.AreEqual(city.CreatedOn, result.CreatedOn);
            Assert.AreEqual(city.IsDeleted, result.IsDeleted);
        }
    }
}
