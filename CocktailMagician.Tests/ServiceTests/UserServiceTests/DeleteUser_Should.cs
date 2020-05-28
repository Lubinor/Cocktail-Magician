using CocktailMagician.Data;
using CocktailMagician.Models;
using CocktailMagician.Services;
using CocktailMagician.Services.DTOs;
using CocktailMagician.Services.Mappers.Contracts;
using CocktailMagician.Services.Providers.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.ServiceTests.UserServiceTests
{
    [TestClass]
    public class DeleteUser_Should
    {
        [TestMethod]
        public async Task ReturnFalse_IfUserMissingOrDeleted()
        {
            //Arrange
            var mockDatetimeProvider = new Mock<IDateTimeProvider>();
            var mockIUserMapper = new Mock<IUserMapper>();

            var options = Utils.GetOptions(nameof(ReturnFalse_IfUserMissingOrDeleted));

            var user = new User
            {
                Id = 1,
                UserName = "George",
            };

            using (var arrangeContext = new CocktailMagicianContext(options))
            {
                arrangeContext.Users.Add(user);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new UserService(mockDatetimeProvider.Object, assertContext, mockIUserMapper.Object);
                var result = await sut.DeleteUserAsync(2);

                Assert.IsFalse(result);
            }
        }

        [TestMethod]
        public async Task DeleteUser_WhenParamsAreValid()
        {
            //Arrange
            var mockDatetimeProvider = new Mock<IDateTimeProvider>();
            var mockIUserMapper = new Mock<IUserMapper>();
            
            var options = Utils.GetOptions(nameof(DeleteUser_WhenParamsAreValid));

            var user = new User
            {
                Id = 1,
                UserName = "George",
            };

            using (var arrangeContext = new CocktailMagicianContext(options))
            {
                arrangeContext.Users.Add(user);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new UserService(mockDatetimeProvider.Object, assertContext, mockIUserMapper.Object);
                var result = await sut.DeleteUserAsync(1);

                var deletedUser = await assertContext.Users.FirstOrDefaultAsync(u => u.Id == 1);

                Assert.IsTrue(result);
                Assert.AreEqual(true, deletedUser.IsDeleted);
            }
        }
    }
}
