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

namespace CocktailMagician.Tests.ServiceTests.BarReviewServiceTests
{
    [TestClass]
    public class CreateBarReviewAsync_Should
    {
        [TestMethod]
        public async Task ReturnNull_IfNoBarReviewDTO()
        {
            //Arrange
            var mockIDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockIBarReviewMapper = new Mock<IBarReviewMapper>();

            var options = Utils.GetOptions(nameof(ReturnNull_IfNoBarReviewDTO));

            var bar = new Bar { Id = 1, Name = "Lorka" };

            using (var arrangeContext = new CocktailMagicianContext(options))
            {
                arrangeContext.Bars.Add(bar);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new BarReviewService(mockIDateTimeProvider.Object, assertContext, mockIBarReviewMapper.Object);

                var result = await sut.CreateBarReviewAsync(null);

                Assert.IsNull(result);
            }
        }

        [TestMethod]
        public async Task ReturnReview_IfParamsAreValid()
        {
            //Arrange
            var mockIDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockIBarReviewMapper = new Mock<IBarReviewMapper>();
            mockIBarReviewMapper
                .Setup(r => r.MapToBarReview(It.IsAny<BarReviewDTO>()))
                .Returns<BarReviewDTO>(r => new BarsUsersReviews { BarId = r.BarId, UserId = r.AuthorId, Comment = r.Comment });

            mockIBarReviewMapper
                .Setup(r => r.MapToBarReviewDTO(It.IsAny<BarsUsersReviews>()))
                .Returns<BarsUsersReviews>(r => new BarReviewDTO { BarId = r.BarId, AuthorId = r.UserId, Comment = r.Comment });

            var options = Utils.GetOptions(nameof(ReturnReview_IfParamsAreValid));

            var bars = Utils.ReturnTwoBars(options);  //1 Lorka, 2 Bilkova
            var users = Utils.ReturnTwoUsers(options); //1 George, 2 Jim
            var reviewDTO = new BarReviewDTO
            {
                BarId = 2,
                AuthorId = 2,
                Comment = "Lorka is the best!"
            };

            using (var arrangeContext = new CocktailMagicianContext(options))
            {
                arrangeContext.Bars.AddRange(bars);
                arrangeContext.Users.AddRange(users);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new BarReviewService(mockIDateTimeProvider.Object, assertContext, mockIBarReviewMapper.Object);

                var result = await sut.CreateBarReviewAsync(reviewDTO);

                Assert.AreEqual(1, assertContext.BarsUsersReviews.Count());
                Assert.AreEqual(2, result.AuthorId);
                Assert.AreEqual(2, result.BarId);
            }
        }
    }
}