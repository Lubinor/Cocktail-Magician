using CocktailMagician.Data;
using CocktailMagician.Models;
using CocktailMagician.Services;
using CocktailMagician.Services.DTOs;
using CocktailMagician.Services.Mappers.Contracts;
using CocktailMagician.Services.Providers.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.ServiceTests.UserServiceTests
{
    [TestClass]
    public class GetUser_Should
    {
        [TestMethod]
        public async Task ReturnNull_IfNoUser()
        {
            //Arrange
            var mockDatetimeProvider = new Mock<IDateTimeProvider>();
            var mockIUserMapper = new Mock<IUserMapper>();

            var options = Utils.GetOptions(nameof(ReturnNull_IfNoUser));

            var user = new User { Id = 1, UserName = "George" };

            using (var arrangeContext = new CocktailMagicianContext(options))
            {
                arrangeContext.Users.Add(user);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new UserService(mockDatetimeProvider.Object, assertContext, mockIUserMapper.Object);
                var result = await sut.GetUserAsync(2);

                Assert.IsNull(result);
            }
        }

        [TestMethod]
        public async Task Return_CorrectUserParams()
        {
            //Arrange
            var mockDatetimeProvider = new Mock<IDateTimeProvider>();
            var mockIUserMapper = new Mock<IUserMapper>();
            mockIUserMapper
                .Setup(x => x.MapToUserDTO(It.IsAny<User>()))
                .Returns<User>(x => new UserDTO { Id = x.Id, UserName = x.UserName, Email = x.Email, PhoneNumber = x.PhoneNumber });

            mockIUserMapper
                .Setup(x => x.MapToUser(It.IsAny<UserDTO>()))
                .Returns<UserDTO>(x => new User { UserName = x.UserName, Email = x.Email, PhoneNumber = x.PhoneNumber });

            var options = Utils.GetOptions(nameof(Return_CorrectUserParams));

            var user = new User { Id = 1, UserName = "George" };
            var user2 = new User { Id = 2, UserName = "Tom" };

            using (var arrangeContext = new CocktailMagicianContext(options))
            {
                arrangeContext.Users.Add(user);
                arrangeContext.Users.Add(user2);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new UserService(mockDatetimeProvider.Object, assertContext, mockIUserMapper.Object);
                var result = await sut.GetUserAsync(2);

                Assert.AreEqual(2, result.Id);
                Assert.AreEqual("Tom", result.UserName);
            }
        }
    }
}
