using CocktailMagician.Data;
using CocktailMagician.Models;
using CocktailMagician.Services;
using CocktailMagician.Services.DTOs;
using CocktailMagician.Services.Mappers.Contracts;
using CocktailMagician.Services.Providers.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq.Dynamic;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.ServiceTests.CocktailReviewServiceTests
{
    [TestClass]
    public class UpdateCocktailReviewAsync_Should
    {
        [TestMethod]
        public async Task ReturnNull_IfNoUpdatedCReviewDTO()
        {
            //Arrange
            var mockIDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockICocktailReviewMapper = new Mock<ICocktailReviewMapper>();
            mockICocktailReviewMapper
                .Setup(r => r.MapToCocktailReview(It.IsAny<CocktailReviewDTO>()))
                .Returns<CocktailReviewDTO>(r => new CocktailsUsersReviews
                { CocktailId = r.CocktailId, UserId = r.AuthorId, Comment = r.Comment });

            mockICocktailReviewMapper
                .Setup(r => r.MapToCocktailReviewDTO(It.IsAny<CocktailsUsersReviews>()))
                .Returns<CocktailsUsersReviews>(r => new CocktailReviewDTO
                { CocktailId = r.CocktailId, AuthorId = r.UserId, Comment = r.Comment });

            var options = Utils.GetOptions(nameof(ReturnNull_IfNoUpdatedCReviewDTO));

            var cocktail = new Cocktail { Id = 1, Name = "Mojito" };

            var user = new User { Id = 1, UserName = "George" };
            var review = new CocktailsUsersReviews
            {
                CocktailId = 1,
                UserId = 1,
                Comment = "Top!",
                Rating = 5
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

                var result = await sut.UpdateCocktailReviewAsync(1, 1, null);

                Assert.IsNull(result);
            }
        }

        [TestMethod]
        public async Task ReturnUpdatedCReview_IfParamsAreValid()
        {
            //Arrange
            var mockIDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockICocktailReviewMapper = new Mock<ICocktailReviewMapper>();
            mockICocktailReviewMapper
                .Setup(r => r.MapToCocktailReview(It.IsAny<CocktailReviewDTO>()))
                .Returns<CocktailReviewDTO>(r => new CocktailsUsersReviews
                { CocktailId = r.CocktailId, UserId = r.AuthorId, Comment = r.Comment, Rating = r.Rating });

            mockICocktailReviewMapper
                .Setup(r => r.MapToCocktailReviewDTO(It.IsAny<CocktailsUsersReviews>()))
                .Returns<CocktailsUsersReviews>(r => new CocktailReviewDTO
                { CocktailId = r.CocktailId, AuthorId = r.UserId, Comment = r.Comment, Rating = r.Rating });


            var options = Utils.GetOptions(nameof(ReturnUpdatedCReview_IfParamsAreValid));

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

            var updatedReview = new CocktailReviewDTO
            {
                CocktailId = 1,
                AuthorId = 2,
                Comment = "Worst!",
                Rating = 1
            };

            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new CocktailReviewService(mockIDateTimeProvider.Object, assertContext, mockICocktailReviewMapper.Object);

                var result = await sut.UpdateCocktailReviewAsync(1, 2, updatedReview);

                Assert.AreEqual("Worst!", result.Comment);
                Assert.AreEqual(1, result.Rating);
                Assert.AreEqual(2, result.AuthorId);
                Assert.AreEqual(1, result.CocktailId);
            }
        }
    }
}