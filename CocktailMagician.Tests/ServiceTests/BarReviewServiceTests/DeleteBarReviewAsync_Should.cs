using CocktailMagician.Data;
using CocktailMagician.Models;
using CocktailMagician.Services;
using CocktailMagician.Services.DTOs;
using CocktailMagician.Services.Mappers.Contracts;
using CocktailMagician.Services.Providers.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.ServiceTests.BarReviewServiceTests
{
    [TestClass]
    public class DeleteBarReviewAsync_Should
    {
        [TestMethod]
        public async Task ReturnNull_IfBarReviewMissingOrDeleted()
        {
            //Arrange
            var mockIDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockIBarReviewMapper = new Mock<IBarReviewMapper>();

            var options = Utils.GetOptions(nameof(ReturnNull_IfBarReviewMissingOrDeleted));

            var bar = new Bar
            {
                Id = 1,
                Name = "Lorka"
            };

            var user = new User { Id = 1, UserName = "George" };
            var review = new BarsUsersReviews
            {
                BarId = 1,
                UserId = 1,
                Comment = "Top!",
            };

            using (var arrangeContext = new CocktailMagicianContext(options))
            {
                arrangeContext.Bars.Add(bar);
                arrangeContext.Users.Add(user);
                arrangeContext.BarsUsersReviews.Add(review);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new BarReviewService(mockIDateTimeProvider.Object, assertContext, mockIBarReviewMapper.Object);

                var result = await sut.DeleteBarReviewAsync(2, 2);

                Assert.IsFalse(result);
            }
        }

        [TestMethod]
        public async Task ReturnTrue_IfBarReviewDeletedSuccesfully()
        {
            //Arrange
            var mockIDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockIBarReviewMapper = new Mock<IBarReviewMapper>();

            var options = Utils.GetOptions(nameof(ReturnTrue_IfBarReviewDeletedSuccesfully));

            var bars = Utils.ReturnTwoBars(options);  //1 Lorka, 2 Bilkova
            var users = Utils.ReturnTwoUsers(options); //1 George, 2 Jim
            var review = new BarsUsersReviews
            {
                BarId = 2,
                UserId = 2,
                Comment = "Top!",
                Rating = 5
            };

            using (var arrangeContext = new CocktailMagicianContext(options))
            {
                arrangeContext.Bars.AddRange(bars);
                arrangeContext.Users.AddRange(users);
                arrangeContext.BarsUsersReviews.Add(review);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new BarReviewService(mockIDateTimeProvider.Object, assertContext, mockIBarReviewMapper.Object);

                var result = await sut.DeleteBarReviewAsync(2, 2);
                var deletedReview = assertContext.BarsUsersReviews
                    .FirstOrDefault(r => r.BarId == 2 && r.UserId == 2);


                Assert.IsTrue(result);
                Assert.AreEqual(true, deletedReview.IsDeleted);
            }
        }
    }
}