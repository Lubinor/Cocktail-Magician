using CocktailMagician.Data;
using CocktailMagician.Services.Contracts;
using CocktailMagician.Services.DTOs;
using CocktailMagician.Services.Mappers.Contracts;
using CocktailMagician.Services.Provider.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Services
{
    public class CocktailService : ICocktailService
    {
        private readonly IDatetimeProvider datetimeProvider;
        private readonly ICocktailMapper mapper;
        private readonly CocktailMagicianContext context;

        public CocktailService(IDatetimeProvider datetimeProvider, ICocktailMapper mapper, CocktailMagicianContext context)
        {
            this.datetimeProvider = datetimeProvider ?? throw new ArgumentNullException(nameof(datetimeProvider));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<ICollection<CocktailDTO>> GetAllCocktailssAsync()
        {
            var cocktails = this.context.Cocktails
                .Include(cocktail => cocktail.Bars)
                .Where(cocktail => cocktail.IsDeleted == false);

            var cocktailDTOs = await cocktails.Select(cocktail => mapper.MapToCocktailDTO(cocktail)).ToListAsync();

            return cocktailDTOs;
        }

        public async Task<CocktailDTO> GetCocktailAsync(int id)
        {
            var cocktail = await this.context.Cocktails
                .Include(cocktail => cocktail.Bars)
                .FirstOrDefaultAsync(cocktail => cocktail.Id == id & cocktail.IsDeleted == false);
            if (cocktail == null)
            {
                return null;
            }
            var cocktailDTO = mapper.MapToCocktailDTO(cocktail);

            return cocktailDTO;
        }
        public async Task<CocktailDTO> CreateCocktailAsync(CocktailDTO coctailDTO)
        {
            if (coctailDTO == null)
            {
                return null;
            }

            var cocktail = mapper.MapToCocktail(coctailDTO);

            this.context.Cocktails.Add(cocktail);
            await this.context.SaveChangesAsync();

            return coctailDTO;
        }
        public async Task<CocktailDTO> UpdateCocktailAsync(int id, CocktailDTO cocktailDTO)
        {
            var cocktail = await this.context.Cocktails
                .FirstOrDefaultAsync(cocktail => cocktail.Id == id & cocktail.IsDeleted == false);

            if (cocktail == null)
            {
                return null;
            }

            cocktail = mapper.MapToCocktail(cocktailDTO);

            this.context.Cocktails.Update(cocktail);
            await this.context.SaveChangesAsync();

            return cocktailDTO;
        }
        public async Task<bool> DeleteCocktailAsync(int id)
        {
            var cocktail = await this.context.Cocktails
                .FirstOrDefaultAsync(cocktail => cocktail.Id == id & cocktail.IsDeleted == false);

            if (cocktail == null)
            {
                return false;
            }

            cocktail.IsDeleted = true;

            this.context.Cocktails.Update(cocktail);
            await this.context.SaveChangesAsync();
            
            return true;
        }
    }
}
