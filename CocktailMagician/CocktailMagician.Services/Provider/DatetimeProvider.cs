using CocktailMagician.Services.Provider.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Services.Provider
{
    public class DatetimeProvider : IDatetimeProvider
    {
        public DateTime GetDateTime() => DateTime.UtcNow;
    }
}
