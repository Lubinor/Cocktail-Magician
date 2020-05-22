﻿using CocktailMagician.Data;
using CocktailMagician.Services;
using CocktailMagician.Services.Mappers;
using CocktailMagician.Services.Mappers.Contracts;
using CocktailMagician.Services.Provider;
using CocktailMagician.Services.Provider.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.ServiceTests.IngredientServiceTests
{
    [TestClass]
    public class DeleteIngredient_Should
    {
        [TestMethod]
        public async Task DeleteIngredient_WhenConditionsAreMet()
        {
            //Arrange
            var mockDatetimeProvider = new Mock<IDatetimeProvider>();
            var mockMapper = new Mock<IIngredientMapper>();
            var mockCocktailMapper = new Mock<CocktailMapper>();
            var options = Utils.GetOptions(nameof(DeleteIngredient_WhenConditionsAreMet));
            Utils.GetInMemoryThreeIngredients(options);

            //Act & Assert
            using (var assertContext = new CocktailMagicianContext(options))
            {
                var sut = new IngredientService(mockDatetimeProvider.Object, mockMapper.Object,
                    mockCocktailMapper.Object, assertContext);
                var result = await sut.DeleteIngredientAsync(3);

                Assert.IsTrue(result);
            }
        }
    }
}
