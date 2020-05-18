using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Services.Provider.Contracts
{
    public interface IDatetimeProvider
    {
        DateTime GetDateTime();
    }
}
