using CocktailMagician.Data;
using CocktailMagician.Models;
using CocktailMagician.Services;
using CocktailMagician.Services.Mappers.Contracts;
using CocktailMagician.Services.Providers.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.ServiceTests.CocktailReviewServiceTests
{
    [TestClass]
    public class GetAllUserCReviewsAsync_Should
    {
        [TestMethod]
        public async Task ReturnEmpty_IfNoUserReviewsForCocktails()
        {
            //Arrange
            var mockIDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockICocktailReviewMapper = new Mock<ICocktailReviewMapper>();

            var options = Utils.GetOptions(nameof(ReturnEmpty_IfNoUserReviewsForCocktails));

            var user = new User { Id = 1, UserName = "George" };

            using (var arrangeContext = new CocktailMagicianContext(options))
            {
                arrangeContext.Users.Add(user);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new CocktailReviewService(mockIDateTimeProvider.Object, assertContext, mockICocktailReviewMapper.Object);

                var result = await sut.GetAllUserReviewsAsync(1);

                Assert.AreEqual(0, result.Count);
            }
        }

        [TestMethod]
        public async Task ReturnCorrect_IfParamsAreValid()
        {
            //Arrange
            var mockIDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockICocktailReviewMapper = new Mock<ICocktailReviewMapper>();

            var options = Utils.GetOptions(nameof(ReturnCorrect_IfParamsAreValid));

            var cocktail = new Cocktail { Id = 1, Name = "Mojito" };
            var users = Utils.ReturnTwoUsers(options); //1 George, 2 Jim
            var reviews = Utils.ReturnTwoCocktailReviews(options);

            using (var arrangeContext = new CocktailMagicianContext(options))
            {
                arrangeContext.Cocktails.Add(cocktail);
                arrangeContext.Users.AddRange(users);
                arrangeContext.CocktailsUsersReviews.AddRange(reviews);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new CocktailReviewService(mockIDateTimeProvider.Object, assertContext, mockICocktailReviewMapper.Object);

                var result = await sut.GetAllUserReviewsAsync(1);

                Assert.AreEqual(1, result.Count);
            }
        }
    }
}
