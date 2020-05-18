using CocktailMagician.Data;
using CocktailMagician.Services.Contracts;
using CocktailMagician.Services.DTOs;
using CocktailMagician.Services.Mappers.Contracts;
using CocktailMagician.Services.Providers.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CocktailMagician.Services
{
    public class BarService : IBarService
    {
        private readonly IDateTimeProvider dateTimeProvider;
        private readonly CocktailMagicianContext context;
        private readonly IBarMapper barMapper;

        public BarService(IDateTimeProvider dateTimeProvider, CocktailMagicianContext context, IBarMapper barMapper)
        {
            this.dateTimeProvider = dateTimeProvider ?? throw new ArgumentNullException(nameof(dateTimeProvider));
            this.context = context ?? throw new ArgumentNullException(nameof(context)); ;
            this.barMapper = barMapper ?? throw new ArgumentNullException(nameof(barMapper)); ;
        }
        public Task<ICollection<BarDTO>> GetAllBarsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BarDTO> GetBarAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<BarDTO> CreateBarAsync(BarDTO barDTO)
        {
            throw new NotImplementedException();
        }

        public Task<BarDTO> UpdateBarAsync(int id, BarDTO barDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletBarAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
