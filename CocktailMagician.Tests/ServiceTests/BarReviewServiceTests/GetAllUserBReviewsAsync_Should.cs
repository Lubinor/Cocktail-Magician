using CocktailMagician.Data;
using CocktailMagician.Models;
using CocktailMagician.Services;
using CocktailMagician.Services.Mappers.Contracts;
using CocktailMagician.Services.Providers.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.ServiceTests.BarReviewServiceTests
{
    [TestClass]
    public class GetAllUserBReviewsAsync_Should
    {
        [TestMethod]
        public async Task ReturnEmpty_IfNoUserReviewsForBars()
        {
            //Arrange
            var mockIDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockIBarReviewMapper = new Mock<IBarReviewMapper>();

            var options = Utils.GetOptions(nameof(ReturnEmpty_IfNoUserReviewsForBars));

            var user = new User { Id = 1, UserName = "George" };

            using (var arrangeContext = new CocktailMagicianContext(options))
            {
                arrangeContext.Users.Add(user);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new BarReviewService(mockIDateTimeProvider.Object, assertContext, mockIBarReviewMapper.Object);

                var result = await sut.GetAllBarReviewsAsync(1);

                Assert.AreEqual(0, result.Count);
            }
        }

        [TestMethod]
        public async Task ReturnProper_IfParamsAreValid()
        {
            //Arrange
            var mockIDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockIBarReviewMapper = new Mock<IBarReviewMapper>();

            var options = Utils.GetOptions(nameof(ReturnProper_IfParamsAreValid));

            var bars = Utils.ReturnTwoBars(options);  //1 Lorka, 2 Bilkova
            var users = Utils.ReturnTwoUsers(options); //1 George, 2 Jim
            var reviews = Utils.ReturnFourBarReviews(options);

            using (var arrangeContext = new CocktailMagicianContext(options))
            {
                arrangeContext.Bars.AddRange(bars);
                arrangeContext.Users.AddRange(users);
                arrangeContext.BarsUsersReviews.AddRange(reviews);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new BarReviewService(mockIDateTimeProvider.Object, assertContext, mockIBarReviewMapper.Object);

                var result = await sut.GetAllUserReviewsAsync(1);

                Assert.AreEqual(2, result.Count);
            }
        }
    }
}
