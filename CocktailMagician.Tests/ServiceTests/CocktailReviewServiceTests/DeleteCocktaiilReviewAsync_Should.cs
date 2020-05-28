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

namespace CocktailMagician.Tests.ServiceTests.CocktailReviewServiceTests
{
    [TestClass]
    public class DeleteCocktailReviewAsync_Should
    {
        [TestMethod]
        public async Task ReturnNull_IfCocktailReviewMissingOrDeleted()
        {
            //Arrange
            var mockIDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockICocktailReviewMapper = new Mock<ICocktailReviewMapper>();

            var options = Utils.GetOptions(nameof(ReturnNull_IfCocktailReviewMissingOrDeleted));

            var cocktail = new Cocktail { Id = 1, Name = "Mojito" };
            var user = new User { Id = 1, UserName = "George" };
            var review = new CocktailsUsersReviews
            {
                CocktailId = 1,
                UserId = 1,
                Comment = "Top!",
            };

            using (var arrangeContext = new CocktailMagicianContext(options))
            {
                arrangeContext.Cocktails.Add(cocktail);
                arrangeContext.Users.Add(user);
                arrangeContext.CocktailsUsersReviews.Add(review);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new CocktailReviewService(mockIDateTimeProvider.Object, assertContext, mockICocktailReviewMapper.Object);

                var result = await sut.DeleteCocktailReviewAsync(2, 2);

                Assert.IsFalse(result);
            }
        }

        [TestMethod]
        public async Task ReturnTrue_IfCocktailReviewDeletedSuccesfully()
        {
            //Arrange
            var mockIDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockICocktailReviewMapper = new Mock<ICocktailReviewMapper>();

            var options = Utils.GetOptions(nameof(ReturnTrue_IfCocktailReviewDeletedSuccesfully));

            var cocktail = new Cocktail { Id = 1, Name = "Mojito" };
            var users = Utils.ReturnTwoUsers(options); //1 George, 2 Jim
            var review = new CocktailsUsersReviews
            {
                CocktailId = 1,
                UserId = 2,
                Comment = "Top!",
                Rating = 5
            };

            using (var arrangeContext = new CocktailMagicianContext(options))
            {
                arrangeContext.Cocktails.Add(cocktail);
                arrangeContext.Users.AddRange(users);
                arrangeContext.CocktailsUsersReviews.Add(review);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new CocktailReviewService(mockIDateTimeProvider.Object, assertContext, mockICocktailReviewMapper.Object);

                var result = await sut.DeleteCocktailReviewAsync(1, 2);
                var deletedReview = assertContext.CocktailsUsersReviews
                    .FirstOrDefault(r => r.CocktailId == 1 && r.UserId == 2);


                Assert.IsTrue(result);
                Assert.AreEqual(true, deletedReview.IsDeleted);
            }
        }
    }
}